using Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.ValueObjects;

namespace Admin.Controllers
{
    public class FoodController : Controller
    {
        public IFoodClient _foodClient;
        public FoodController(IFoodClient foodClient)
        {
            _foodClient = foodClient;
        }
        public async Task<IActionResult> Index()
        {
            var foods = await _foodClient.GetAll();
            return View(foods);
        }
        public async Task<IActionResult> Detail(string foodId)
        {
            VFood food = await _foodClient.GetById(foodId);
            return View(food);
        }
    }
}
