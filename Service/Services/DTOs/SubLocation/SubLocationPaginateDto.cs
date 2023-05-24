using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.DTOs.SubLocation
{
    public class SubLocationPaginateDto
    {
        public int Length { get; set; }
        public IEnumerable<SubLocationDto> SubLocationDtos { get; set; }
    }
}
