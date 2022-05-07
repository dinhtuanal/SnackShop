using BusinessLogicLayer.Interfaces;
using Data.DbContext;
using Data.Entities;
using SharedObjects.Commons;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly SnackShopDbContext _context;
        public CategoryService(SnackShopDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(CategoryViewModel model)
        {
            var category = new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = model.CategoryName,
                Description = model.Description,
                Status = (Status)model.Status
            };
            _context.Categories.Add(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delele(string categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if(category == null)
            {
                throw new SnackShopException("Can not find category"); 
            }
            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync();
        }

        public List<VCategory> GetAll()
        {
            var categories = _context.Categories.ToList();
            var vCategories = categories.ConvertAll(
                x => new VCategory
                {
                    CategoryId=x.CategoryId,
                    CategoryName=x.CategoryName,
                    Description=x.Description
                }
            );
            return vCategories;
        }

        public async Task<VCategory> GetById(string categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category == null)
            {
                throw new SnackShopException("Can not find category");
            }
            var vCategory = new VCategory
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
            return vCategory;
        }

        public async Task<int> Update(CategoryViewModel model)
        {
            var category = await _context.Categories.FindAsync(model.CategoryId);
            if (category == null)
            {
                throw new SnackShopException("Can not find category");
            }
            category.CategoryName = model.CategoryName;
            category.Description = model.Description;
            _context.Categories.Update(category);
            return _context.SaveChanges();
        }
    }
}
