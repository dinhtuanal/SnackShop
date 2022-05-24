using Clients.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;

namespace Admin.Controllers
{
    [Authorize]
    public class FoodController : Controller
    {
        private readonly IFoodClient _foodClient;
        private readonly ISubCategoryClient _subCategoryClient;

        public FoodController(IFoodClient foodClient, ISubCategoryClient subCategoryClient)
        {
            _foodClient = foodClient;
            _subCategoryClient = subCategoryClient;
        }
        public async Task<IActionResult> Index()
        {
            var foods = await _foodClient.GetAll();
            return View(foods);
        }
        [AllowAnonymous]
        public async Task<IActionResult> GetPagination_Pta([FromBody]PageViewModel model)
        {
            var result = await _foodClient.GetPagination(model);
            return PartialView(result);
        }
        [AllowAnonymous]
        public async Task<JsonResult> CountPagination()
        {
            int count = await _foodClient.CountPagination();
            return Json(new { result = count });
        }
        public async Task<IActionResult> Detail(string foodId)
        {
            VFood food = await _foodClient.GetById(foodId);
            return View(food);
        }
        public async Task<JsonResult> GetById(string foodId)
        {
            var food = await _foodClient.GetById(foodId);
            return Json(new { result = food });
        }
        public async Task<IActionResult> Add(string foodId)
        {
            if (string.IsNullOrEmpty(foodId))
            {
                ViewBag.FoodId = "";
            }
            ViewBag.FoodId = foodId;
            var subcategories = await _subCategoryClient.GetAll();
            return View(subcategories);
        }
        [HttpPost]
        public async Task<JsonResult> Save([FromBody] FoodViewModel model)
        {
            string token = User.GetSpecificClaim("token");
            int result;
            if (string.IsNullOrEmpty(model.FoodId))
            {
                result = await _foodClient.Add(model, token);
                if(result == 200)
                {
                    return Json(new { statusCode = 1 });
                }
                return Json(new { statusCode = result });
            }
            result = await _foodClient.Update(model, token);
            if (result == 200)
            {
                return Json(new { statusCode = 2 });
            }
            return Json(new { statusCode = result });
        }
        public async Task<IActionResult> Delete(string foodId)
        {
            string token = User.GetSpecificClaim("token");
            var result = await _foodClient.Delete(foodId, token);
            return Json(new { statusCode = result });
        }
    }
}
