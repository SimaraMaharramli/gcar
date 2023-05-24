using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Service.DTOs.User;
using Service.Services.Interfaces;

namespace Service.Services
{
    //public class UserService : IUserService
    //{
    //    private readonly UserManager<AppUser> _userManager;
    //    private readonly AppDbContext _context;
    //    private readonly ICurrentUserService _currentUserService;

    //    public UserService(UserManager<AppUser> userManager,
    //        ICurrentUserService currentUserService,
    //        AppDbContext context
    //       )
    //    {
    //        _userManager = userManager;
    //        _currentUserService = currentUserService;
    //        _context = context;

    //    }

    //    public async Task<UserInfoDTO> GetUserInfo()
    //    {
    //        CurrentUserInfoDto currentUser = _currentUserService.GetCurrentUser();
    //        return await _userManager.Users.Where(c => c.Id == currentUser.id).Select(u => new UserInfoDTO()
    //        {
    //            FullName = u.Fullname,
    //            Email = u.Email,
    //            Phone = u.PhoneNumber
    //        }).FirstOrDefaultAsync();
    //    }

    //}
}
