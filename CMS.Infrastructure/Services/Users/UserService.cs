using AutoMapper;
using CMS.Core.Constants;
using CMS.Core.Dtos;
using CMS.Core.Exceptions;
using CMS.Core.ViewModels;
using CMS.Data;
using CMS.Data.Models;
using CMS.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Query = CMS.Core.Dtos.Query;

namespace CMS.Infrastructure.Services.Users
{
    public class UserService : IUserService
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
        public async Task<byte[]> ExportToExcel()
        {
            var users = await _db.Users.Where(x => !x.IsDelete).ToListAsync();

            return ExcelHelpers.ToExcel(new Dictionary<string, ExcelColumn>
            {
                {"FullName", new ExcelColumn("FullName", 0)},
                {"Email", new ExcelColumn("Email", 1)},
                {"Phone", new ExcelColumn("Phone", 2)}
            }, new List<ExcelRow>(users.Select(e => new ExcelRow
            {
                Values = new Dictionary<string, string>
                {
                    {"FullName", e.FullName},
                    {"Email", e.Email},
                    {"Phone", e.PhoneNumber}
                }
            })));
        }
        public async Task<string> SetFCMToUser(string userId, string fcmToken)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == userId && !x.IsDelete);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            user.FCMToken = fcmToken;
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user.Id;
        }
 
        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Users.Where(x => !x.IsDelete && (x.FullName.Contains(query.GeneralSearch) 
                                                                || string.IsNullOrWhiteSpace(query.GeneralSearch) 
                                                                || x.Email.Contains(query.GeneralSearch) 
                                                                || x.PhoneNumber.Contains(query.GeneralSearch))).AsQueryable();
            
            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList =  queryString.ToList().Skip(skipValue).Take(pagination.PerPage);
            var users = _mapper.Map<List<UserViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = users,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pages,
                    total = dataCount,
                }
            };
            return result;
        }
        public void g() {


            var user = _db.Users.SingleOrDefault(x => x.FullName == "Fuck");
            var c = _manager.CheckPasswordAsync(user, "SadegSadeg2001");

            var x = 1;

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
        public UserViewModel GetUserByUsername(string username)
        {
            var user = _db.Users.SingleOrDefault(x => x.UserName == username && !x.IsDelete);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UserViewModel>(user);
        }
        public async Task<string> Create(CreateUserDto dto)
        {
            var emailOrPhoneIsExit = await _db.Users.AnyAsync(x => !x.IsDelete && (x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber));
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
        public async Task<List<UserViewModel>> GetAuthorList()
        {
            var users = await _db.Users.Where(x => !x.IsDelete && x.UserType == Core.Enums.UserType.ArticleAuthor).ToListAsync();
            return _mapper.Map<List<UserViewModel>>(users);
        }
        public async Task<string> Update(UpdateUserDto dto)
        {
            var emailOrPhoneIsExit = await _db.Users.AnyAsync(x => !x.IsDelete && (x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber) && x.Id != dto.Id);
            if (emailOrPhoneIsExit)
            {
                throw new DuplicateEmailOrPhoneException();
            }
            var user = await _db.Users.FindAsync(dto.Id);
            var updatedUSer = _mapper.Map<UpdateUserDto, User>(dto,user);

            if (dto.Image != null)
            {
                updatedUSer.ImageUrl = await _fileService.SaveFile(dto.Image, FolderNames.ImagesFolder);
            }
            _db.Users.Update(updatedUSer);
            await _db.SaveChangesAsync();
            return user.Id;

        }

        public async Task<UpdateUserDto> Get(string Id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateUserDto>(user);
        }
        private string GeneratePassword()
        {
            return Guid.NewGuid().ToString().Substring(1, 7);

        }
    }
}
