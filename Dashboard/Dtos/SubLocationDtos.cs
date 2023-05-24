using Domain.Entities;
using Service.Services.DTOs.Location;
using Service.Services.DTOs.SubLocation;

namespace Dashboard.Dtos
{
    public class SubLocationDtos
    {
        public List<SubLocationDto>? SubLocationDto { get; set; }
        public string? Name { get; set; }
    }
}
