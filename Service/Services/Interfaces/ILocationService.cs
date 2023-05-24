using Service.Services.DTOs.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ILocationService
    {
        Task CreateAsync(LocationCreateDto locationtCreateDto);
        Task UpdateAsync(int id, LocationEditDto location);
        Task DeleteAsync(int id);
        Task<List<LocationDto>> GetAllAsync();
        Task<LocationDto> GetAsync(int id);
        Task<LocationDto> GetByIdAsync(int id);
        Task<IEnumerable<LocationDto>> GetAllNameAsync(string name);
    }
}
