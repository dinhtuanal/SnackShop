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
        public IActionResult Role()
        {
            return View();
        }
        public async Task<IActionResult> GetAll_Pta()
        {
            var token = User.GetSpecificClaim("token");
            var result = await _roleClient.GetAll(token);
            return PartialView(result);
        }
        public async Task<JsonResult> Delete(string id)
        {
            string token = User.GetSpecificClaim("token");
            var result = await _roleClient.Delete(id, token);
            return Json(new { statusCode = result });
        }
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] RoleViewModel model)
        {
            string token = User.GetSpecificClaim("token");
            int result;
            if (string.IsNullOrEmpty(model.RoleId))
            {
                result = (await _roleClient.Add(model, token)).StatusCode;
                if(result == 200)
                {
                    return Json(new { statusCode = 1 });
                }
                return Json(new { statusCode = 0 });
            }
            result = (await _roleClient.Update(model,token)).StatusCode;
            if(result == 200)
            {
                return Json(new { statusCode = 2 });
            }
            return Json(new { statusCode = 0 });
        }
        public async Task<JsonResult> GetById(string id)
        {
            string token = User.GetSpecificClaim("token");
            var role = await _roleClient.GetById(id,token);
            return Json(new { result = role });
        }
        
    }
}
