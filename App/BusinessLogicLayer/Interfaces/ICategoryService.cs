using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICategoryService
    {
        public Task<int> Add(CategoryViewModel model);
        public Task<int> Update(CategoryViewModel model);
        public Task<int> Delele(string categoryId);
        public Task<VCategory> GetById(string categoryId);
        public List<VCategory> GetAll();
    }
}
