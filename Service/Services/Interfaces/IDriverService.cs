using Domain.Entities;
using Service.Services.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IDriverService
    {
        Task<ApiResponse> RegisterDriverAsync(RegisterDriverDto model);

    }
}
