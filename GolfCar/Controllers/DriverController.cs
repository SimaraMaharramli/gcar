using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.DTOs.Account;
using Service.Services.Interfaces;

namespace GolfCar.Controllers
{
    public class DriverController : AppController
    {
        private readonly IDriverService _driverService;
        private readonly IWebHostEnvironment _env;
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly IEmailService _emailService;
        public DriverController(RoleManager<IdentityRole> roleManager, IAccountService accountService, IWebHostEnvironment env, UserManager<AppUser> userManager, IDriverService driverService /*IEmailService emailService*/)
        {
            _driverService = driverService;
            _env = env;
            _accountService = accountService;
            _userManager = userManager;
            _roleManager = roleManager;
            //_emailService = emailService;
        }



        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            var dbUser = await _userManager.FindByEmailAsync(user.Email);
            if (dbUser == null || !await _userManager.CheckPasswordAsync(dbUser, user.Password))
            {
                return Unauthorized();
            }
            if (await _userManager.IsInRoleAsync(dbUser, "Driver"))
            {
                return Ok(await _accountService.LoginAsync(user));
            }
            return NotFound("Buraya daxil ola bilmersiniz");


        }

    }
}
