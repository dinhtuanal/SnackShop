using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedObjects.Commons;
using SharedObjects.ViewModels;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(userService.GetAll());
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetById(string userId)
        {
            try
            {
                var user = await userService.GetById(userId);
                return Ok(user); //json
            }
            catch (SnackShopException ex)
            {
                return BadRequest(ex.Message); //string
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await userService.Add(model);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [Authorize(Roles = "admin")]
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(UpdateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await userService.Update(model);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("delete/{userId}")]
        public async Task<IActionResult> Delete(string userId)
        {
            var result = await userService.Delete(userId);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await userService.Login(model);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else if (result.StatusCode == 404)
            {
                return NotFound();
            }
            return BadRequest(result);
        }
    }
}
