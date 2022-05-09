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
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;
        public SubCategoriesController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }
        [HttpGet]
        public List<VSubCategory> GetAll()
        {
            return _subCategoryService.GetAll();
        }
        [HttpGet]
        [Route("{subCategoryId}")]
        public Task<VSubCategory> GetById(string subCategoryId)
        {
            return _subCategoryService.GetById(subCategoryId);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] SubCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _subCategoryService.Add(model);
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
        public async Task<IActionResult> Update([FromBody] SubCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _subCategoryService.Update(model);
            if (result != 0)
            {
                return Ok(new ResponseResult(200));
            }
            return BadRequest(new ResponseResult(400));
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("delete/{subCategoryId}")]
        public async Task<IActionResult> Delete(string subCategoryId)
        {
            var result = await _subCategoryService.Delete(subCategoryId);
            if(result != 0)
            {
                return Ok(new ResponseResult(200));
            }
            return BadRequest(400);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("{categoryId}/subcategory")]
        public async Task<List<VSubCategory>> GetByCategoryId(string categoryId)
        {
            return await _subCategoryService.GetByCategoryId(categoryId);
            
        }
    }
}
