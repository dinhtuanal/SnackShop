using SharedObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Interfaces
{
    public interface ICartClient
    {
        public Task<int> AddToCart(string id);
        public Task<List<CartItem>> GetAllItem();
    }
}
