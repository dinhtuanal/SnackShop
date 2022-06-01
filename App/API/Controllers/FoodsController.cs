using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Add([FromBody] FoodViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _foodService.Add(model);
            if (result != 0)
            {
                return Ok(new ResponseResult(200));
            }
            return BadRequest(new ResponseResult(400));
        }
        [HttpPut]
        [Route("update")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update([FromBody] FoodViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _foodService.Update(model);
            if (result != 0)
            {
                return Ok(new ResponseResult(200));
            }
            return BadRequest(new ResponseResult(400));
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("delete/{foodId}")]
        public async Task<IActionResult> Delete(string foodId)
        {
            var result = await _foodService.Delete(foodId);
            if (result != 0)
            {
                return BadRequest(new ResponseResult(400));
            }
            return Ok(new ResponseResult(200));
        }
        [HttpGet]
        [Route("get-by-subcategoryid/{subCategoryId}")]
        public async Task<List<VFood>> GetBySubCategoryId(string subCategoryId)
        {
            return await _foodService.GetBySubCategoryId(subCategoryId);
        }
        [HttpPost]
        [Route("get-pagination")]
        public List<VFood> GetPagination(PageViewModel model)
        {
            return _foodService.GetPagination(model);
        }
        [HttpGet]
        [Route("count-pagination")]
        public int CountPagination()
        {
            return _foodService.CountPagination();
        }
    }
}
