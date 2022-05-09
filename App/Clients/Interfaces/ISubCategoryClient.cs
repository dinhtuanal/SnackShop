using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Interfaces
{
    public interface ISubCategoryClient
    {
        public Task<int> Add(SubCategoryViewModel model, string token);
        public Task<int> Update(SubCategoryViewModel model, string token);
        public Task<int> Delete(string subCategoryId, string token);
        public Task<List<VSubCategory>> GetAll();
        public Task<VSubCategory> GetById(string subCategoryId);
        public Task<List<VSubCategory>> GetByCategoryId(string categoryId);
    }
}
