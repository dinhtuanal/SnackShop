using Clients.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Authorize]
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
