using Microsoft.AspNetCore.Identity;
using SharedObjects.Commons;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        Task<ResponseResult> Login(LoginViewModel model);
        Task<ResponseResult> Add(AddUserViewModel model);
        Task<ResponseResult> Update(UpdateUserViewModel model);
        Task<ResponseResult> Delete(string userId);
        List<IdentityUser> GetAll();
        Task<IdentityUser> GetById(string userId);
    }
}
