using Clients.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.ValueObjects;

namespace Admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryClient _categoryClient;
        public CategoryController(ICategoryClient categoryClient)
        {
            _categoryClient = categoryClient;
        }
        public async Task<IActionResult> Index(){
            List<VCategory> categories = await _categoryClient.GetAll();
            return View(categories);
        }

    }
}
