using Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace Admin.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleClient _roleClient;
        public RoleController(IRoleClient roleClient)
        {
            _roleClient = roleClient;
        }
        public async Task<IActionResult> Role()
        {
            string token = User.GetSpecificClaim("token");
            var roles = await _roleClient.GetAll(token);
            return View(roles);
        }
        public async Task<IActionResult> Update(string roleId)
        {
            string token = User.GetSpecificClaim("token");
            var role = await _roleClient.GetById(roleId, token);
            RoleViewModel model = new RoleViewModel()
            {
                RoleId = role.Id,
                RoleName = role.Name,
            };
            return View(model);
        }
    }
}
