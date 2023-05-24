using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.DTOs.Order
{
    public class OrderDto
    {
        public string? UserId { get; set; }
        public string? DriverId { get; set; }
        public Domain.Entities.Location? Location { get; set; }
        public Domain.Entities.SubLocation? SubLocation { get; set; }
        public Domain.Entities.Location? Destination { get; set; }
    }
}
