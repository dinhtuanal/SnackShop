using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ISubCategoryService
    {
        public Task<int> Add(SubCategoryViewModel model);
        public Task<int> Update(SubCategoryViewModel model);
        public Task<int> Delete(string subCategoryId);
        public List<VSubCategory> GetAll();
        public Task<VSubCategory> GetById(string subCategoryId);
        public Task<List<VSubCategory>> GetByCategoryId ( string categoryId);

    }
}
