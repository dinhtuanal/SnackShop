using Clients.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryClient.GetAll();
            return View(categories);
        }
    }
}
