using HealthClaim.API.Services;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.UsersDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HealthClaim.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _signInManager;
        public readonly TokenService _tokenService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            ApplicationUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);
            if (user == null) return Unauthorized();

            var result = _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (result.IsCompletedSuccessfully)
            {
                return CreateUserObject(user);
            }
            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email taken");
            }
            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.UserName))
            {
                return BadRequest("Username taken");
            }

            var user = new ApplicationUser
            {
                FirstName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                //PasswordHash = registerDto.Password
            };

            await _userManager.AddPasswordAsync(user, registerDto.Password);
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                return CreateUserObject(user);
            }
            return BadRequest("Problem in regestring user");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            ApplicationUser? user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));
            return CreateUserObject(user);
        }

        private UserDto CreateUserObject(ApplicationUser user)
        {
            return new UserDto
            {
                DisplayName = user.FirstName,
                //Image = user?.Photos?.FirstOrDefault(x => x.IsMain)?.Url,
                Token = _tokenService.CrateToken(user),
                UserName = user.UserName
            };
        }
    }
}

