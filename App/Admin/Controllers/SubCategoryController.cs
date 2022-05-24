using Clients.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace Admin.Controllers
{
    [Authorize]
    public class SubCategoryController : Controller
    {
        private ISubCategoryClient _subCategoryClient;
        private ICategoryClient _categoryClient;
        public SubCategoryController(ISubCategoryClient subCategoryClient, ICategoryClient categoryClient)
        {
            _subCategoryClient = subCategoryClient;
            _categoryClient = categoryClient;
        }
        public async Task<IActionResult> Index()
        {
            var subcategories = await _subCategoryClient.GetAll();
            return View(subcategories);
        }
        public async Task<IActionResult> GetById(string subCategoryId)
        {
            var subCategory = await _subCategoryClient.GetById(subCategoryId);
            return Json(new {result = subCategory});
        }
        public async Task<IActionResult> Add(string subCategoryId)
        {
            if (string.IsNullOrEmpty(subCategoryId))
            {
                ViewBag.SubCategoryId = "";
            }
            ViewBag.SubCategoryId = subCategoryId;
            var categories = await _categoryClient.GetAll();
            return View(categories);
        }
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SubCategoryViewModel model)
        {
            var token = User.GetSpecificClaim("token");
            int result;
            if (model.SubCategoryId == "")
            {
                result = await _subCategoryClient.Add(model, token);
                if(result == 200)
                {
                    return Json(new { statusCode = 1 });
                }
                return Json(new { statusCode = 0 });
            }
            else
            {
                result = await _subCategoryClient.Update(model, token);
                if (result == 200)
                {
                    return Json(new { statusCode = 2 });
                }
                return Json(new { statusCode = 0 });
            }
        }
        public async Task<IActionResult> Delete(string subCategoryId)
        {
            var token = User.GetSpecificClaim("token");
            var result = await _subCategoryClient.Delete(subCategoryId, token);
            return Json(new {statusCode = result});
        }
    }
}
