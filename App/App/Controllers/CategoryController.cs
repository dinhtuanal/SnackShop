using Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryClient _categoryClient;
        private readonly ISubCategoryClient _subCategoryClient;
        public CategoryController(ISubCategoryClient subCategoryClient, ICategoryClient categoryClient)
        {
            _subCategoryClient = subCategoryClient;
            _categoryClient = categoryClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(string categoryId)
        {
            var subCates = await _subCategoryClient.GetByCategoryId(categoryId);
            ViewBag.CategoryId = categoryId;
            return View(subCates);
        }
    }
}
