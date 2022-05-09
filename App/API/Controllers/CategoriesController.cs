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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public List<VCategory> GetAll()
        {
            return _categoryService.GetAll();
        }
        [HttpGet]
        [Route("{categoryId}")]
        public async Task<VCategory> GetById(string categoryId)
        {
            return await _categoryService.GetById(categoryId);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody]CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseResult(400));
            }
            var result = await _categoryService.Add(model);
            if (result != 0)
            {
                return Ok(new ResponseResult(200));
            }
            return BadRequest(new ResponseResult(400));
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody]CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseResult(400));
            }
            var result = await _categoryService.Update(model);
            if (result != 0)
            {
                return Ok(new ResponseResult(200));
            }
            return BadRequest(new ResponseResult(400));
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("delete/{categoryId}")]
        public async Task<IActionResult> Delete(string categoryId)
        {
            var result = await _categoryService.Delele(categoryId);
            if(result != 0)
            {
                return Ok(new ResponseResult(200));
            }
            return BadRequest(new ResponseResult(400));
        }
    }
}
