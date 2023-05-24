using Service.Services.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<string?> LoginAsync(LoginDto model);
        Task<ApiResponse> RegisterAsync(RegisterDto model);
        Task CreateRole(RoleDto model);
		Task AddUserToRole(string userId, string role);
        Task RemoveAccount();
        //Task<string> ChangeUserPass(string userId, ChangePasswordDto passwordDto);
    }
}
