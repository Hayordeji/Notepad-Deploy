using API.DTO.Account;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;    
        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("auth/register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var appUser = new AppUser
                {
                    Email = registerData.Email,
                    UserName = registerData.Username
                };
                var createdUser = _userManager.CreateAsync(appUser,registerData.Password);

                if (createdUser.IsCompletedSuccessfully)
                {
                    var roleResult = _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.IsCompletedSuccessfully)
                    {
                        return Ok("Account created successfully");
                    }
                    else
                    {
                        return StatusCode(500,roleResult.Result);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Result);
                }


            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex);
            }
        }
    }
    
}
