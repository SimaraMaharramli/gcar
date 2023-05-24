using Microsoft.AspNetCore.Http;
using Service.DTOs.User;

namespace Service.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserInfoDTO> GetUserInfo();
        //Task<string> SetLanguage(string code);

    }
}
