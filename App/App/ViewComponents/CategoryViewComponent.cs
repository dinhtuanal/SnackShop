using Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryClient _categoryClient;
        public CategoryViewComponent(ICategoryClient categoryClient)
        {
            _categoryClient = categoryClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cates = await _categoryClient.GetAll();
            return View(cates);
        }
    }
}
