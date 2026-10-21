using ISC_JWTToken_API.DTO;
using ISC_JWTToken_API.Models;
using ISC_JWTToken_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ISC_JWTToken_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly UserManager<ApplicationUser> userManager;
        public readonly SignInManager<ApplicationUser> signInManager;
        public readonly ITokenService tokenService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (registerDTO == null)
            {
                return BadRequest("Invalid Data Provided!");
            }
            else
            {
                ApplicationUser _user = new ApplicationUser();
                _user.UserName = registerDTO.UserName;
                _user.Email = registerDTO.Email;

                var result = await userManager.CreateAsync(_user, registerDTO.Password);
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(_user, registerDTO.Role);
                    return Ok("User Created Successfully!");
                }
                else
                {
                    return BadRequest("Failed to Create User!");
                }
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user = await userManager.FindByNameAsync(loginDTO.UserName);
            if(user == null)
            {
                return BadRequest("Invalid User Name!");
            }
            var result = await signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if(!result.Succeeded)
            {
                return BadRequest("Invalid Password!");
            }
            else
            {
                var roles = await userManager.GetRolesAsync(user);
                var token = tokenService.CreateToken(user, roles.ToList());
                return Ok(new { token });
            }
        }

    }
}
