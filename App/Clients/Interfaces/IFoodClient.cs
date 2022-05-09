using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Interfaces
{
    public interface IFoodClient
    {
        public Task<int> Add(FoodViewModel model,string token);
        public Task<int> Update(FoodViewModel model, string token);
        public Task<int> Delete(string foodId, string token);
        public Task<VFood> GetById(string foodId);
        public Task<List<VFood>> GetAll();
        public Task<List<VFood>> GetBySubCategoryId(string subCategoryId);
    }
}
