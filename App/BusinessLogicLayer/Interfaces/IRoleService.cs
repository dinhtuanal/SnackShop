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
    public interface IRoleService
    {
        public Task<ResponseResult> Add(RoleViewModel model);
        public Task<ResponseResult> Update(RoleViewModel model);
        public Task<ResponseResult> Delete(string roleId);
        public List<IdentityRole> GetAll();
        public Task<IdentityRole> GetById(string roleId);
        public Task<ResponseResult> AssignRole(UserRoleViewModel model);
        public Task<ResponseResult> RemoveRole(UserRoleViewModel model);
        public Task<List<IdentityUser>> GetUserInRole(string roleName);
        public Task<List<IdentityUser>> GetUserNotInRole(string roleName);
    }
}
