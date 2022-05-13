using Clients.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace Admin.Controllers
{
    [Authorize]
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
        public IActionResult Add() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string token = User.GetSpecificClaim("token");
            var result = await _roleClient.Add(model, token);
            if (result.StatusCode == 200)
            {
                return RedirectToAction("role");
            }
            foreach(var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty,item);
            }
            return View(model);
        }
    }
}
