using Microsoft.EntityFrameworkCore.Diagnostics;
using Service.Services.DTOs.Location;
using Service.Services.DTOs.SubLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ISubLocationService
    {
        Task CreateAsync(SubLocationCreateDto eventCreateDto);
        Task UpdateAsync(int id, SubLocationEditDto levent);
        Task DeleteAsync(int id);
        Task<List<SubLocationDto>> GetAllAsync();
        Task<SubLocationDto> GetAsync(int id);
        Task<SubLocationDto> GetByIdAsync(int id);
        Task<List<SubLocationDto>> GetByLocationId(int id);
        Task<IEnumerable<SubLocationDto>> GetAllNameAsync(string name);
        Task<SubLocationPaginateDto> Paginate(int num);
    }
}
