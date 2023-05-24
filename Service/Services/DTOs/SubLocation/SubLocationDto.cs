using Service.Services.DTOs.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.DTOs.SubLocation
{
    public class SubLocationDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int LocationId { get; set; }
        public LocationDto? Location { get; set; }
    }
}
