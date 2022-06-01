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
    public class FoodService : IFoodService
    {
        private readonly SnackShopDbContext _context;
        public FoodService(SnackShopDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(FoodViewModel model)
        {
            var food = new Food
            {
                FoodId = Guid.NewGuid(),
                Name = model.Name,
                Price = model.Price,
                Image = model.Image,
                Description = model.Description,
                Content = model.Content,
                Status = (Status)model.Status,
                DateCreated = DateTime.Now,
                SubCategoryId = Guid.Parse(model.SubCategoryId)
            };
            _context.Foods.Add(food);
            return await _context.SaveChangesAsync();
        }

        public int CountPagination()
        {
            var query = from f in _context.Foods
                        join s in _context.SubCategories
                        on f.SubCategoryId equals s.SubCategoryId
                        select new VFood()
                        {
                            FoodId = f.FoodId,
                            Name = f.Name,
                            Price= f.Price,
                            Image= f.Image,
                            Description= f.Description,
                            Content= f.Content,
                            Status= f.Status,
                            DateCreated = f.DateCreated,
                            SubCategoryId = f.SubCategoryId,
                            SubCategoryName = s.SubCategoryName
                        };
            return query.ToList().Count();
        }

        public async Task<int> Delete(string foodId)
        {
            var food = await _context.Foods.FindAsync(Guid.Parse(foodId));
            if(food == null)
            {
                throw new SnackShopException("Can not find this food");
            }
            _context.Foods.Remove(food);
            return await _context.SaveChangesAsync();
        }

        public  VFood Get(string foodId)
        {
            var food =  _context.Foods.Find(Guid.Parse(foodId));
            if(food == null)
            {
                return null;
            }
            return new VFood
            {
                FoodId = Guid.Parse(foodId),
                Name = food.Name,
                Price = food.Price,
                Image = food.Image,
                Description = food.Description,
                Content = food.Content,
                DateCreated = food.DateCreated,
            };
        }

        public List<VFood> GetAll()
        {
            var query = from f in _context.Foods
                       join s in _context.SubCategories
                       on f.SubCategoryId equals s.SubCategoryId
                       select new VFood
                       {
                           FoodId = f.FoodId,
                           Name = f.Name,
                           Price = f.Price,
                           Image = f.Image,
                           Description = f.Description,
                           Content = f.Content,
                           Status = f.Status,
                           DateCreated = f.DateCreated,
                           SubCategoryId = f.SubCategoryId,
                           SubCategoryName = s.SubCategoryName
                       };
            return query.ToList();
        }

        public async Task<VFood> GetById(string foodId)
        {
            try
            {
                var food = await _context.Foods.FindAsync(Guid.Parse(foodId));
                if (food == null)
                {
                    throw new SnackShopException("Can not find this food ");
                }
                var query = from f in _context.Foods
                            join s in _context.SubCategories
                            on f.SubCategoryId equals s.SubCategoryId
                            select new VFood
                            {
                                FoodId = f.FoodId,
                                Name = f.Name,
                                Price = f.Price,
                                Image = f.Image,
                                Description = f.Description,
                                Content = f.Content,
                                Status = f.Status,
                                DateCreated = f.DateCreated,
                                SubCategoryId = f.SubCategoryId,
                                SubCategoryName = s.SubCategoryName
                            };
                var vFood = query.Where(x => x.FoodId == Guid.Parse(foodId)).FirstOrDefault();
                if (vFood == null)
                {
                    throw new SnackShopException("Can not find this food");
                }
                return vFood;
            }catch (Exception)
            {
                throw new SnackShopException("Lỗi gì đó");
            }
        }

        public async Task<List<VFood>> GetBySubCategoryId(string subCategoryId)
        {
            var subCategory = await _context.SubCategories.FindAsync(Guid.Parse(subCategoryId));
            if(subCategory == null)
            {
                throw new SnackShopException("Can not find food with subcategory id: " +  subCategoryId);
            }
            var query = from f in _context.Foods
                        join s in _context.SubCategories
                        on f.SubCategoryId equals s.SubCategoryId
                        select new VFood
                        {
                            FoodId = f.FoodId,
                            Name = f.Name,
                            Price = f.Price,
                            Image = f.Image,
                            Description = f.Description,
                            Content = f.Content,
                            Status = f.Status,
                            DateCreated = f.DateCreated,
                            SubCategoryId = f.SubCategoryId,
                            SubCategoryName = s.SubCategoryName
                        };
            var vFoods = query.Where(x => x.SubCategoryId == Guid.Parse(subCategoryId)).ToList();
            if (vFoods == null)
            {
                throw new SnackShopException("Can not find this food");
            }
            return vFoods;
        }

        public List<VFood> GetPagination(PageViewModel model)
        {
            var query = from f in _context.Foods
                        join s in _context.SubCategories
                        on f.SubCategoryId equals s.SubCategoryId
                        select new VFood()
                        {
                            FoodId = f.FoodId,
                            Name = f.Name,
                            Price = f.Price,
                            Image = f.Image,
                            Description = f.Description,
                            Content = f.Content,
                            Status = f.Status,
                            DateCreated = f.DateCreated,
                            SubCategoryId = f.SubCategoryId,
                            SubCategoryName = s.SubCategoryName
                        };
            var foods = query.Skip((model.PageIndex-1)*model.PageSize).Take(model.PageSize).ToList();
            return foods;
        }

        public async Task<int> Update(FoodViewModel model)
        {
            var food = await _context.Foods.FindAsync(Guid.Parse(model.FoodId));
            if(food == null)
            {
                throw new SnackShopException("Can not find this food");
            }
            food.Name = model.Name;
            food.Price = model.Price;
            food.Image = model.Image;
            food.Description = model.Description;
            food.Content = model.Content;
            food.Status = (Status)model.Status;
            _context.Foods.Update(food);
            return await _context.SaveChangesAsync();
        }
    }
}
