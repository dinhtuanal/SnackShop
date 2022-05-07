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
        public async Task<IActionResult> GetById(string subCategoryId)
        {
            var subCategory =  await _subCategoryService.GetById(subCategoryId);
            if(subCategory == null)
            {
                return BadRequest(new ResponseResult(404));
            }
            return Ok(subCategory);
        }
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
    }
}
