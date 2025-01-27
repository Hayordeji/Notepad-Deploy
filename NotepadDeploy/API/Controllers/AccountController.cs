using API.DTO.Account;
using API.Models;
using API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
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
                var createdUser = await _userManager.CreateAsync(appUser, registerData.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(new NewUserDto
                        {
                            Username = registerData.Username,
                            Email = registerData.Email,
                            Token = await _tokenService.CreateTokenAsync(appUser)
                        });
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
               


            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("auth/login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginData.EmailOrUsername || x.Email == loginData.EmailOrUsername.ToLower());
            if (user == null)
            {
                return Unauthorized("Username or Email Address not found");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginData.Password,false);
            if (!result.Succeeded) 
            { 
                return Unauthorized("Incorrect Password");
            }
            return Ok(new NewUserDto
            {
                Email = user.Email,
                Username = user.UserName,
                Token = await _tokenService.CreateTokenAsync(user),
            });

        }
    }
    
}
