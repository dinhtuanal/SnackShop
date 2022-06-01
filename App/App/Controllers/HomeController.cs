using App.Models;
using Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFoodClient _foodClient;
        private readonly ISubCategoryClient _subCategoryClient;

        public HomeController(ILogger<HomeController> logger, IFoodClient foodClient, ISubCategoryClient subCategoryClient)
        {
            _logger = logger;
            _foodClient = foodClient;
            _subCategoryClient = subCategoryClient;
        }

        public async Task<IActionResult> Index()
        {
            var subCates = await _subCategoryClient.GetAll();
            ViewBag.SubCates = subCates;
            return View(await _foodClient.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}