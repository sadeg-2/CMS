using CMS.Core.Dtos;
using CMS.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Services.Users
{
    public interface IUserService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<string> Delete(string id);
        Task<string> Create(CreateUserDto dto);
        Task<string> Update(UpdateUserDto dto);
        Task<UpdateUserDto> Get(string Id);
        Task<List<UserViewModel>> GetAuthorList();
        public void g();
    }
}
