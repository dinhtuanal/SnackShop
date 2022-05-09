using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Interfaces
{
    public interface ICategoryClient
    {
        public Task<List<VCategory>> GetAll();
        public Task<VCategory> GetById(string categoryId);
        public Task<int> Add(CategoryViewModel model, string token);
        public Task<int> Update(CategoryViewModel model, string token);
        public Task<int> Delete(string categoryId, string token);
    }
}
