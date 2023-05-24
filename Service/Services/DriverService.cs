using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Services.DTOs.Account;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DriverService:IDriverService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        //private readonly ICurrentUserService _currentUserService;

        public DriverService(/*ICurrentUserService currentUserService,*/UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            //_currentUserService = currentUserService;
            _config = config;
            _mapper = mapper;
        }

        //public async Task<ApiResponse> LoginDriverAsync(LoginDto model)
        //{
        //    var dbUser = await _userManager.FindByEmailAsync(model.Email);

        //    if (dbUser.IsDelete) throw new Exception(/*_localizing["NameOrPasswordIncorrect"]*/ "Email və ya şifrə yalnışdır");

        //    if (dbUser == null) throw new Exception(/*_localizing["NameOrPasswordIncorrect"]*/ "Email və ya şifrə yalnışdır");


        //    var roles = await _userManager.GetRolesAsync(dbUser);


        //    return GenerateJwtToken(dbUser.UserName, (List<string>)roles);
        //}

        private string GenerateJwtToken(string username, List<string> roles)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, username)
        };

            roles.ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_config["Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ApiResponse> RegisterDriverAsync(RegisterDriverDto model)
        {
            var user = new Driver { UserName = model.Email, Email = model.Email, PasswordHash = model.Password, Fullname = model.Fullname,GolfCarId=model.GolfCarId };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                ApiResponse response = new()
                {
                    Errors = result.Errors.Select(m => m.Description).ToList(),
                    StatusMessage = "Failed"
                };
                return response;
            }

            var dbUser = await _userManager.FindByEmailAsync(model.Email);

            await _userManager.AddToRoleAsync(dbUser, "Driver");
            return new ApiResponse { Errors = null, StatusMessage = "Succes" };

        }


        //[HttpPost]
        //public async Task<IActionResult> LoginDriver([FromBody] LoginDto user)
        //{
        //    return Ok(await _accountService.LoginAsync(user));
        //}
    }
}
