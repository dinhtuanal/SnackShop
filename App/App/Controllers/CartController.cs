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
        private readonly IFoodService _foodService;
        public CartController(IFoodService foodService)
        {
            _foodService = foodService;
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
        public IActionResult AddToCart(string id)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.Id == id);
            if (item == null)
            {
                var food = _foodService.Get(id);
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
            return Ok();
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
            //var cart = await _cartClient.GetAllItem();
            return View(myCart);
        }
    }
}
