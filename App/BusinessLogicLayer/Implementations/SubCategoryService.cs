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
            var query = from s in _context.SubCategories
                        join c in _context.Categories
                        on s.CategoryId equals c.CategoryId
                        select new VSubCategory
                        {
                            SubCategoryId = s.SubCategoryId,
                            SubCategoryName = s.SubCategoryName,
                            Description = s.Description,
                            DateCreated = s.DateCreated,
                            Status = s.Status,
                            CategoryId = s.CategoryId,
                            CategoryName = c.CategoryName
                        };
            return query.ToList();
        }

        public async Task<List<VSubCategory>> GetByCategoryId(string categoryId)
        {
            var categories = await _context.Categories.FindAsync(Guid.Parse(categoryId));
            if(categories == null)
            {
                throw new SnackShopException("Can not find subcategory with categoryid " + categoryId);
            }
            var query = from s in _context.SubCategories
                        join c in _context.Categories
                        on s.CategoryId equals c.CategoryId
                        select new VSubCategory
                        {
                            SubCategoryId = s.SubCategoryId,
                            SubCategoryName = s.SubCategoryName,
                            Description = s.Description,
                            DateCreated = s.DateCreated,
                            Status = s.Status,
                            CategoryId = s.CategoryId,
                            CategoryName = c.CategoryName
                        };
            var subCategories = query.Where(x => x.CategoryId == Guid.Parse(categoryId)).ToList();
            return subCategories;
            
        }

        public async Task<VSubCategory> GetById(string subCategoryId)
        {
            var subCategories = await _context.SubCategories.FindAsync(Guid.Parse(subCategoryId));
            if(subCategories == null)
            {
                throw new SnackShopException("Can not find subcategory with id: " + subCategoryId);
            }
            var query = from s in _context.SubCategories
                        join c in _context.Categories
                        on s.CategoryId equals c.CategoryId
                        select new VSubCategory
                        {
                            SubCategoryId = s.SubCategoryId,
                            SubCategoryName = s.SubCategoryName,
                            Description = s.Description,
                            DateCreated = s.DateCreated,
                            Status = s.Status,
                            CategoryId = s.CategoryId,
                            CategoryName = c.CategoryName
                        };
            var vSubCategory = query.Where(s => s.SubCategoryId == Guid.Parse(subCategoryId)).FirstOrDefault();
            if (vSubCategory == null)
            {
                throw new SnackShopException("Can not find this sub category");
            }
            return vSubCategory;
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
