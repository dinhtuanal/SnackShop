using API.Helpers;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.ValueObjects;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public CartsController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        public List<CartItem> Carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("Cart");
                if(data == null)
                {
                    data = new List<CartItem>();
                }
                return data;
            }
        }
        [HttpPost]
        [Route("add-to-cart")]
        public IActionResult AddToCart(string id)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p=>p.Id == id);
            if(item == null)
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
        [Route("get-all-item")]
        public List<CartItem> GetAllItem()
        {
            var carts = HttpContext.Session.Get<List<CartItem>>("Cart");
            return carts;
        }
    }
}
