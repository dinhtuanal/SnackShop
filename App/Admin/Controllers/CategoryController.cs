using Clients.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;

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
        public async Task<IActionResult> Index()
        {
            List<VCategory> categories = await _categoryClient.GetAll();
            return View(categories);
        }
        public IActionResult Add() => View();
        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var token = User.GetSpecificClaim("token");
            var result = await _categoryClient.Add(model, token);
            if (result == 0)
            {
                return View(model);
            }
            return RedirectToAction("Index", "Category");
        }
        public async Task<IActionResult> Update(string categoryId)
        {
            var category = await _categoryClient.GetById(categoryId);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            CategoryViewModel model = new CategoryViewModel()
            {
                CategoryId = category.CategoryId.ToString(),
                CategoryName = category.CategoryName,
                Description = category.Description
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var token = User.GetSpecificClaim("token");
            var result = await _categoryClient.Update(model, token);
            if (result == 200)
            {
                return RedirectToAction("index", "category");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(string categoryId)
        {
            var category = await _categoryClient.GetById(categoryId);
            CategoryViewModel model = new CategoryViewModel()
            {
                CategoryId = categoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Status = (int)category.Status
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CategoryViewModel model)
        {
            string token = User.GetSpecificClaim("token");
            var result = await _categoryClient.Delete(model.CategoryId, token);
            if(result == 200 )
            {
                TempData["AlertMessage"] = "Xóa thành công";
                TempData["AlertType"] = "alert alert-success mb-3";
                return RedirectToAction("index","category");
            }
            TempData["AlertMessage"] = "Xóa không thành công";
            TempData["AlertType"] = "alert alert-danger mb-3";
            return RedirectToAction("index", "category");
        }
    }
}
