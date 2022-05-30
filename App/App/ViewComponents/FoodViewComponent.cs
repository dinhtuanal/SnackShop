using Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.ViewComponents
{
    public class FoodViewComponent : ViewComponent
    {
        private readonly IFoodClient _foodClient;
        public FoodViewComponent(IFoodClient foodClient)
        {
            _foodClient = foodClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var foods = await _foodClient.GetAll();
            return View(foods);
        }

    }
}
