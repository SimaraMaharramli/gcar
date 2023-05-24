using Microsoft.AspNetCore.Http;
using Service.DTOs.User;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CurrentUserSrvice : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserSrvice(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUserInfoDto GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var userId = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            return new CurrentUserInfoDto { Id = userId };
        }
    }
}
