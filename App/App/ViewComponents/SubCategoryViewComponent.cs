using Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.ValueObjects;

namespace App.ViewComponents
{
    public class SubCategoryViewComponent : ViewComponent
    {
        private readonly ISubCategoryClient _subCategoryClient;
        private readonly ICategoryClient _categoryClient;
        public SubCategoryViewComponent(ISubCategoryClient subCategoryClient, ICategoryClient categoryClient)
        {
            _subCategoryClient = subCategoryClient;
            _categoryClient = categoryClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cates = await _categoryClient.GetAll();
            ViewBag.Categories = cates;
            List<VSubCategory> subCates = await _subCategoryClient.GetAll();
            return View(subCates);
        }
    }
}
