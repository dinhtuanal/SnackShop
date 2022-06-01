using Clients.Interfaces;
using Newtonsoft.Json;
using SharedObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Implementations
{
    public class CartClient : BaseClient, ICartClient
    {
        public async Task<int> AddToCart(string id)
        {
            var response = await httpClient.GetAsync("carts/add-to-cart");
            return (int)response.StatusCode;
        }
        public async Task<List<CartItem>> GetAllItem()
        {
            var response = await httpClient.GetAsync("carts/get-all-item");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CartItem>>(content);
        }
    }
}
