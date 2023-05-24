using Domain.Entities;
using GolfCar.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.DTOs.Account;
using Service.Services.Interfaces;
using ServiceLayer.Services.Interfaces;

namespace Application.Controllers
{
    public class AccountController : AppController
    {
        private readonly IAccountService _accountService;
        private readonly IDriverService _driverService;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;
        //private readonly IEmailService _emailService;
        private readonly ICurrentUserService _currentUserService;

        public AccountController(IAccountService accountService, IWebHostEnvironment env, UserManager<AppUser> userManager, IDriverService driverService /*IEmailService emailService*/, ICurrentUserService currentUserService)
        {
            _driverService = driverService;
            _accountService = accountService;
            _env = env;
            _userManager = userManager;
            _currentUserService = currentUserService;
            //_emailService = emailService;
        }

        [HttpPost]
        public async Task<ApiResponse> Register([FromBody] RegisterDto user)
        {
            return await _accountService.RegisterAsync(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            var dbUser = await _userManager.FindByEmailAsync(user.Email);
            if (dbUser == null || !await _userManager.CheckPasswordAsync(dbUser, user.Password))
            {
                return Unauthorized();
            }
            if (await _userManager.IsInRoleAsync(dbUser, "Member"))
            {
                return Ok(await _accountService.LoginAsync(user));
            }
            return NotFound("Buraya daxil ola bilmersiniz");

        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleDto role)
        {
            await _accountService.CreateRole(role);
            return Ok();
        }

        [HttpPost]
        public async Task<ApiResponse> RegisterDriver([FromBody] RegisterDriverDto user)
        {
            return await _driverService.RegisterDriverAsync(user);
        }


        [HttpDelete]
        [Route("DeleteAccount")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteAccount()
        {
            await _accountService.RemoveAccount();
            return Ok();
        }
    }
}
