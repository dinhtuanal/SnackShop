using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IFoodService
    {
        public Task<int> Add(FoodViewModel model);
        public Task<int> Update(FoodViewModel model);
        public Task<int> Delete(string foodId);
        public Task<VFood> GetById(string foodId);
        public List<VFood> GetAll();
        public Task<List<VFood>> GetBySubCategoryId(string subCategoryId);
        public int CountPagination();
        public List<VFood> GetPagination(PageViewModel model);
    }
}
