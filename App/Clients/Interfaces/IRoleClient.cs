using Microsoft.AspNet.Identity.EntityFramework;
using SharedObjects.Commons;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Interfaces
{
    public interface IRoleClient
    {
        public Task<ResponseResult> Add(RoleViewModel model,string token);
        public Task<ResponseResult> Update(RoleViewModel model, string token);
        public Task<ResponseResult> Delete(string roleId, string token);
        public Task<List<IdentityRole>> GetAll(string token);
        public Task<IdentityRole> GetById(string roleId, string token);
        public Task<ResponseResult> AssignRole(UserRoleViewModel model, string token);
        public Task<ResponseResult> RemoveRole(UserRoleViewModel model, string token);
        public Task<List<IdentityUser>> GetUserInRole(string roleName, string token);
        public Task<List<IdentityUser>> GetUserNotInRole(string roleName, string token);
    }
}
