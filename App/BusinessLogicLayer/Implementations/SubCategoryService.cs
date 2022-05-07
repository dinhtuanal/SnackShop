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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly SnackShopDbContext _context;
        public SubCategoryService(SnackShopDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(SubCategoryViewModel model)
        {
            var subCategory = new SubCategory()
            {
                SubCategoryId = Guid.NewGuid(),
                SubCategoryName = model.SubCategoryName,
                Description = model.Description,
                Status = (Status)model.Status,
                DateCreated = DateTime.Now,
                CategoryId = Guid.Parse(model.CategoryId)
            };
            _context.SubCategories.Add(subCategory);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(string subCategoryId)
        {
            var subCategory = await _context.SubCategories.FindAsync(Guid.Parse(subCategoryId));
            if(subCategory == null)
            {
                throw new SnackShopException("Can not find sub category");
            }
            _context.SubCategories.Remove(subCategory);
            return await _context.SaveChangesAsync();
        }

        public List<VSubCategory> GetAll()
        {
            var subCategories = _context.SubCategories.ToList();
            var vSubCategories = subCategories.ConvertAll(s => new VSubCategory
            {
                SubCategoryId= s.SubCategoryId,
                SubCategoryName= s.SubCategoryName,
                Description= s.Description,
                DateCreated= s.DateCreated,
                Status=s.Status,
                CategoryId=s.CategoryId
            });
            return vSubCategories;
        }

        public async Task<VSubCategory> GetById(string subCategoryId)
        {
            var subCategory = await _context.SubCategories.FindAsync(Guid.Parse(subCategoryId));
            if(subCategory == null)
            {
                throw new SnackShopException("Can not find sub category");
            }
            return new VSubCategory {
                SubCategoryId = subCategory.SubCategoryId,
                SubCategoryName = subCategory.SubCategoryName,
                Description = subCategory.Description,
                DateCreated = subCategory.DateCreated,
                Status = subCategory.Status,
                CategoryId = subCategory.CategoryId
            };
        }

        public async Task<int> Update(SubCategoryViewModel model)
        {
            var subCategory = await _context.SubCategories.FindAsync(Guid.Parse(model.SubCategoryId));
            if (subCategory == null)
            {
                throw new SnackShopException("Can not find sub category");
            }
            subCategory.SubCategoryName = model.SubCategoryName;
            subCategory.Description = model.Description;
            subCategory.DateCreated = model.DateCreated;
            subCategory.Status = (Status)model.Status;
            subCategory.CategoryId = Guid.Parse(model.CategoryId);
            _context.SubCategories.Update(subCategory);
            return await _context.SaveChangesAsync();
        }
    }
}
