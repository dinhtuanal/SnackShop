using App.Helpers;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.ValueObjects;

namespace App.ViewComponents
{
    public class SmallCartViewComponent : ViewComponent
    {

        public SmallCartViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CartItem> carts = HttpContext.Session.Get<List<CartItem>>("Cart");
            float total = 0;
            var cartItems = 0;
            if (carts == null)
            {
                carts = new List<CartItem>();
            }
            else
            {
                foreach (var item in carts)
                {
                    total += (float)item.TotalPrice;
                    cartItems += item.Qty;
                }
            }
            ViewBag.CartItems = cartItems;
            ViewBag.TotalPrice = total;
            return View(carts);
        }
    }
}
