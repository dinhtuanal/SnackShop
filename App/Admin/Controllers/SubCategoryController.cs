using Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class SubCategoryController : Controller
    {
        private ISubCategoryClient _subCategoryClient;
        public SubCategoryController(ISubCategoryClient subCategoryClient)
        {
            _subCategoryClient = subCategoryClient;
        }
        public async Task<IActionResult> Index()
        {
            var subcategories = await _subCategoryClient.GetAll();
            return View(subcategories);
        }
    }
}
