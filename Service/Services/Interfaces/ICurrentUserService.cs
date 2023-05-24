using Service.DTOs.User;

namespace Service.Services.Interfaces
{
    public interface ICurrentUserService
    {
        CurrentUserInfoDto GetCurrentUser();
    }
}
