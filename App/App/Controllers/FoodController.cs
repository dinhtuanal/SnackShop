using Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodClient _foodClient;
        public FoodController(IFoodClient foodClient)
        {
            _foodClient = foodClient;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(string id)
        {
            var food = await _foodClient.GetById(id);
            var subcategoryId = food.SubCategoryId.ToString();
            var relatedProducts = await _foodClient.GetBySubCategoryId(subcategoryId);
            ViewBag.RelatedProducts = relatedProducts;
            return View(food);
        }
    }
}
