using AutoMapper;
using CMS.Core.Constants;
using CMS.Core.Dtos;
using CMS.Core.Exceptions;
using CMS.Core.ViewModels;
using CMS.Data.Models;
using CMS.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Services.Users
{
    internal class UserService
    {
        private readonly CMSDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _manager;
        private readonly IFileService _fileService;
        private readonly IEmailService _emailService;
        public UserService(CMSDbContext db, IMapper mapper, UserManager<User> manager, IFileService fileService, IEmailService emailService)
        {
            _db = db;
            _mapper = mapper;
            _manager = manager;
            _fileService = fileService;
            _emailService = emailService;
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var users = await _db.Users.Where(x => !x.IsDelete).ToListAsync();

            return _mapper.Map<List<UserViewModel>>(users);
        }


        public async Task<string> Delete(string id)
        {

            var user = await _db.Users.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == id);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            user.IsDelete = true;
            _db.Users.Update(user);
            _db.SaveChanges();

            return user.Id;
        }

        public async Task<string> Create(UserDto dto)
        {
            var emailOrPhoneIsExit = await _db.Users.AnyAsync(x => !x.IsDelete && (x.Email != dto.Email || x.PhoneNumber != dto.PhoneNumber));
            if (emailOrPhoneIsExit)
            {
                throw new DuplicateEmailOrPhoneException();
            }
            var user = _mapper.Map<User>(dto);
            user.UserName = dto.Email;
            if (dto.Image !=null)
            {
                user.ImageUrl = await _fileService.SaveFile(dto.Image,FolderNames.ImagesFolder);
            }
            var password = GeneratePassword();
            var result = await _manager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                throw new OperationFailedException();
            }
            await _emailService.Send(user.Email,"New Account !",$"Ussername is :{user.UserName} , Password:{password}");
            
            
            return user.Id;

        }
        public async Task<string> Update(UserDto dto)
        {
            var emailOrPhoneIsExit = await _db.Users.AnyAsync(x => !x.IsDelete && (x.Email != dto.Email || x.PhoneNumber != dto.PhoneNumber) && x.Id != dto.Id);
            if (emailOrPhoneIsExit)
            {
                throw new DuplicateEmailOrPhoneException();
            }
            var user = await _db.Users.FindAsync(dto.Id);
            var updatedUSer = _mapper.Map<UserDto,User>(dto,user);

            if (dto.Image != null)
            {
                updatedUSer.ImageUrl = await _fileService.SaveFile(dto.Image, FolderNames.ImagesFolder);
            }
            _db.Users.Update(updatedUSer);
            await _db.SaveChangesAsync();
            return user.Id;

        }
        private string GeneratePassword()
        {
            return Guid.NewGuid().ToString().Substring(1, 8);

        }
    }
}
