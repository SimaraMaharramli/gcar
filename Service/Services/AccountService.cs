using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Services.DTOs.Account;
using Service.Services.Interfaces;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;
        private readonly ICurrentUserService _currentUserService;

        public AccountService(ITokenService tokenService ,ICurrentUserService currentUserService, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,IMapper mapper, IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _tokenService= tokenService;
            _currentUserService = currentUserService;
            _config = config;
        }

        public async Task CreateRole(RoleDto model)
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = model.Role });
        }

        public async Task<string?> LoginAsync(LoginDto model)
        {
            var dbUser = await _userManager.FindByEmailAsync(model.Email);

            if (dbUser.IsDelete) throw new Exception(/*_localizing["NameOrPasswordIncorrect"]*/ "Email və ya şifrə yalnışdır");

            if (dbUser == null) throw new Exception(/*_localizing["NameOrPasswordIncorrect"]*/ "Email və ya şifrə yalnışdır");


            var roles = await _userManager.GetRolesAsync(dbUser);


            return GenerateJwtToken(dbUser.UserName, (List<string>)roles);
        }

        public async Task<ApiResponse> RegisterAsync(RegisterDto model)
        {
            var user = new User { UserName = model.Email, Email = model.Email, PasswordHash = model.Password,Fullname=model.Fullname };
            IdentityResult result =  await _userManager.CreateAsync(user ,model.Password);

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

            await _userManager.AddToRoleAsync(dbUser, "Member");
            return new ApiResponse { Errors = null, StatusMessage= "Succes" };
          
        }

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
        public async Task AddUserToRole(string email, string role)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null) return;

            await _userManager.AddToRoleAsync(user, role);
        }

        public async Task RemoveAccount()
        {
            var user = _currentUserService.GetCurrentUser();
            var appUser = await _userManager.FindByIdAsync(user.Id);
            appUser.IsDelete = true;
            await _userManager.UpdateAsync(appUser);
        }

        //public async Task<string> ChangeUserPass(string userId, ChangePasswordDto passwordDto)
        //{
        //        var user = await _userManager.FindByIdAsync(userId);

        //        var result = await _userManager.CheckPasswordAsync(user, passwordDto.CurrentPass);

        //        if (result)
        //        {
        //            var resetPassToken = await _userManager.GeneratePasswordResetTokenAsync(user);

        //            var passChangeResult = await _userManager.ResetPasswordAsync(user, resetPassToken, passwordDto.NewPass);

        //            var roles = await _userManager.GetRolesAsync(user);

        //            return _tokenService.CreateToken(user, roles);
        //        }
        //        else
        //        {
        //            throw new Exception(_localizing["changePassword"]);
        //        }
            

        //}
    }
}
