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

        public List<VFood> GetAll()
        {
            var foods = _context.Foods.ToList();
            var vFoods = foods.ConvertAll(x => 
                new VFood { 
                    FoodId = x.FoodId,
                    Name = x.Name, 
                    Price = x.Price, 
                    Image = x.Image,
                    Description = x.Description,
                    Content= x.Content,
                    Status= x.Status,
                    DateCreated= x.DateCreated,
                }
            );
            return vFoods;
        }

        public async Task<VFood> GetById(string foodId)
        {
            var food = await _context.Foods.FindAsync(Guid.Parse(foodId));
            if (food == null)
            {
                throw new SnackShopException("Can not find food");
            }
            return new VFood
            {
                FoodId = food.FoodId,
                Name = food.Name,
                Price = food.Price,
                Image = food.Image,
                Description = food.Description,
                Content = food.Content,
                Status = food.Status,
                DateCreated = food.DateCreated
            };
        }

        public List<VFood> GetBySubCategoryId(string subCategoryId)
        {
            var foods = from x in _context.Foods
                        where x.SubCategoryId == Guid.Parse(subCategoryId)
                        select new VFood
                        {
                            FoodId = x.FoodId,
                            Name = x.Name,
                            Price = x.Price,
                            Image = x.Image,
                            Description = x.Description,
                            Content = x.Content,
                            Status = x.Status,
                            DateCreated = x.DateCreated,
                            SubCategoryId = x.SubCategoryId
                        };
            return foods.ToList();
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
