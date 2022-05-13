using Clients.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using SharedObjects.Commons;
using SharedObjects.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserClient _userClient;
        private readonly IConfiguration _configuration;
        public AccountController(IUserClient userClient, IConfiguration configuration)
        {
            _userClient = userClient;
            _configuration = configuration;
        }
        public IActionResult Login() => View();
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _userClient.Login(model);
            if (result.StatusCode == 200)
            {

                var userPrincipal = ValidateToken(result.Message);
                var authProperty = new AuthenticationProperties()
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(2),
                    IsPersistent = model.RememberMe
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authProperty);

                return Redirect("/Home/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Sai tên đăng nhập hoặc mật khẩu");
                return View(model);
            }
        }
        private ClaimsPrincipal ValidateToken(string token)
        {
            IdentityModelEventSource.ShowPII = true;
            SecurityToken validateToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();
            validationParameters.ValidateLifetime = true;
            validationParameters.ValidAudience = _configuration["Jwt:Audience"];
            validationParameters.ValidIssuer = _configuration["Jwt:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out validateToken);


            #region luu token vao cookie
            //đưa token vào claim con
            var claims = new List<Claim>() { new Claim("token", token), };
            //đưa claim con vào claim identity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);
            principal.AddIdentity(claimsIdentity);
            #endregion
            return principal;
        }
        public async Task<IActionResult> Account()
        {
            var token = User.GetSpecificClaim("token");
            var users = await _userClient.GetAll(token);
            return View(users);
        }
        public IActionResult Add() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
            var token = User.GetSpecificClaim("token");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _userClient.Add(model, token);
            if (result.StatusCode==200)
            {
                return RedirectToAction("Account");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item);
            }
            return View(model);
        }
        public async Task<IActionResult> Update(string userId)
        {
            try
            {
                var token = User.GetSpecificClaim("token");
                var user = await _userClient.GetById(userId, token);
                UpdateUserViewModel model = new UpdateUserViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                };
                return View(model);
            }
            catch (SnackShopException ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi");
                return View(model);
            }
            var token = User.GetSpecificClaim("token");
            var result = await _userClient.Update(model,token);
            if (result.StatusCode == 200)
            {
                return RedirectToAction("account");
            }
            if (result.StatusCode == 400 || result.StatusCode == 500)
            {
                return NotFound();
            }
            ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi");
            return View(model);
        }
    }
}
