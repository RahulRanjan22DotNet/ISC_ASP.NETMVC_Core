using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISC_JWTToken_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [Authorize(Roles ="Admin,User")]
        [HttpGet("GetUserInfo")]
        public IActionResult GetUserInfo()
        {
            return Ok($"Hello! User : {User.Identity.Name}, you are authorized to access!");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAdminInfo")]
        public IActionResult GetAdminInfo()
        {
            return Ok($"Hello! Admin : {User.Identity.Name}, you are authorized to access!");
        }
    }
}
