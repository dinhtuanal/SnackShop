using Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}
