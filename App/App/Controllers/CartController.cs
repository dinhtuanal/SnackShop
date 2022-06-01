using App.Helpers;
using BusinessLogicLayer.Interfaces;
using Clients.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.ValueObjects;

namespace App.Controllers
{
    public class CartController : Controller
    {
        private readonly IFoodClient _foodClient;
        public CartController(IFoodClient foodClient)
        {
            _foodClient = foodClient;
        }
        public List<CartItem> Carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("Cart");
                if (data == null)
                {
                    data = new List<CartItem>();
                }
                return data;
            }
        }
        [HttpPost]
        public async Task<JsonResult> AddToCart(string id)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.Id == id);
            if (item == null)
            {
                var food = await _foodClient.GetById(id);
                item = new CartItem
                {
                    Id = id,
                    Name = food.Name,
                    Image = food.Image,
                    Price = food.Price,
                    Qty = 1,
                    TotalPrice = food.Price
                };
                myCart.Add(item);
            }
            else
            {
                item.Qty++;
                item.TotalPrice += item.Price;
            }
            HttpContext.Session.Set("Cart", myCart);
            return Json(new {result = 1});
        }
        [HttpGet]
        public List<CartItem> GetAllItem()
        {
            var carts = HttpContext.Session.Get<List<CartItem>>("Cart");
            return carts;
        }
        public async Task<IActionResult> Index()
        {
            List<CartItem> myCart = HttpContext.Session.Get<List<CartItem>>("Cart");
            return View(myCart);
        }
    }
}
