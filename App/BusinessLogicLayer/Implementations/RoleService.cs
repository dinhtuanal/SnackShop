using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using SharedObjects.Commons;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<ResponseResult> Add(RoleViewModel model)
        {
            var role = new IdentityRole(model.RoleName);
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return new ResponseResult(200);
            }
            var errors = new List<string>();
            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }
            return new ResponseResult(404, errors);
        }

        public async Task<ResponseResult> AssignRole(UserRoleViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            var result = await _userManager.AddToRoleAsync(user, model.RoleName);
            if (result.Succeeded)
            {
                return new ResponseResult(200);
            }
            return new ResponseResult(400);
        }

        public async Task<ResponseResult> Delete(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return new ResponseResult(404);
            }
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return new ResponseResult(200);
            }
            var errors = new List<string>();
            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }
            return new ResponseResult(400, errors);
        }

        public List<IdentityRole> GetAll()
        {
            return _roleManager.Roles.ToList();
        }

        public async Task<IdentityRole> GetById(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                throw new SnackShopException("Can not find role");
            }
            return role;
        }

        public async Task<List<IdentityUser>> GetUserInRole(string roleName)
        {
            return (await _userManager.GetUsersInRoleAsync(roleName)).ToList();
        }

        public async Task<List<IdentityUser>> GetUserNotInRole(string roleName)
        {
            var users = _userManager.Users.ToList();
            var usersNotInRole = new List<IdentityUser>();
            foreach (var user in users)
            {
                if (!await _userManager.IsInRoleAsync(user, roleName))
                {
                    usersNotInRole.Add(user);
                }
            }
            return usersNotInRole;
        }

        public async Task<ResponseResult> RemoveRole(UserRoleViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
            if (result.Succeeded)
            {
                return new ResponseResult(200);
            }
            return new ResponseResult(400);
        }

        public async Task<ResponseResult> Update(RoleViewModel model)
        {
            var role = await GetById(model.RoleId);
            if (role == null)
            {
                return new ResponseResult(404);
            }
            role.Name = model.RoleName;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return new ResponseResult(200);
            }
            var errors = new List<string>();
            foreach (var item in result.Errors)
            {
                errors.Add(item.Description);
            }
            return new ResponseResult(400, errors);
        }
    }
}
