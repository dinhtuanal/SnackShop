using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        [HttpGet]
        public List<VFood> GetAll()
        {
            return _foodService.GetAll();
        }
        [HttpGet]
        [Route("{foodId}")]
        public Task<VFood> GetById(string foodId)
        {
            return _foodService.GetById(foodId);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] FoodViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _foodService.Add(model);
            if (result != 0)
            {
                return BadRequest(new ResponseResult(400));
            }
            return Ok(new ResponseResult(200));
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] FoodViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _foodService.Update(model);
            if (result != 0)
            {
                return BadRequest(new ResponseResult(400));
            }
            return Ok(new ResponseResult(200));
        }
        [HttpDelete]
        [Route("delete/{foodId}")]
        public async Task<IActionResult> Delete(string foodId)
        {
            var result = await _foodService.Delete(foodId);
            if(result != 0)
            {
                return BadRequest(new ResponseResult(400));
            }
            return Ok(new ResponseResult(200));
        }
        [HttpGet]
        [Route("{subCategoryId}/food")]
        public async Task<List<VFood>> GetBySubCategoryId(string subCategoryId)
        {
            return await _foodService.GetBySubCategoryId(subCategoryId);
        }
    }
}
