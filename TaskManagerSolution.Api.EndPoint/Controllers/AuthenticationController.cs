using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerSolution.Api.EndPoint.Models.Dtos.UserDto;
using TaskManagerSolution.Application.Interfaces.IFasde;

namespace TaskManagerSolution.Api.EndPoint.Controllers {
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase {
        private readonly IUserFasade _user;

        public AuthenticationController(IUserFasade user) {
            _user = user;
        }

        [HttpPost]
        [Route("/api/auth/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginParameter)
        {
            var signupResult = _user.LoginUserService.LoginUser(loginParameter.UserName, loginParameter.Password)
                .Result;
            if (signupResult.IsSuccess == true) {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,signupResult.Result.UserId.ToString()),
                    new Claim(ClaimTypes.GivenName, loginParameter.UserName),
                    new Claim(ClaimTypes.Name, signupResult.Result.Name),
                    new Claim(ClaimTypes.Role, signupResult.Result.Role ),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties() {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Ok(signupResult);
        }
        [HttpGet]
        [Route("/api/auth/signout")]
        public async Task<IActionResult> SignOut() {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok("کاربر از سیستم خارج شد");
        }
    }
}
