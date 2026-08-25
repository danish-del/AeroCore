using AeroCore.Infrastructure.Identity;
using AeroCore.Infrastructure.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AeroCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JwtService _jwt;
        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, JwtService jwt)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwt = jwt;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string email, string password)
        {
            var user = new AppUser
            {
                UserName = username,
                Email = email
            };
            var result = await _userManager.CreateAsync(user, password);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user  = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return Unauthorized("Invalid Email or Password");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if(!result.Succeeded)
            {
                return Unauthorized("Invalid Email or Password");
            }
            var token = _jwt.GenerateToken(user);
            return Ok(new
            {
                message = "Login Successfull",
                token = token
            });
        }
    }
}
