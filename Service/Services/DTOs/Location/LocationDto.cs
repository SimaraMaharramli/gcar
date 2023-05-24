using Service.Services.DTOs.SubLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.DTOs.Location
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List< SubLocationDto>? SubLocation { get; set; }
    }   
}
