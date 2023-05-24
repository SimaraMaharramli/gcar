using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Order:BaseEntity
	{
        public string? AppUserId { get; set; }
        public AppUser? AppUsers { get; set; }
        public Driver? Drivers { get; set; }
        public string? DriverId { get; set; }
        public int LocationId { get; set; }
        public int SubLocationId { get; set; }
        public int DestinationId { get; set; }
        public Location? Locations { get; set; }
        public Location? Destination { get; set; }  
        public SubLocation? SubLocations { get; set; }
        public string? FareDetails { get; set; }
        public OrderStatus Status { get; set; }

    }
}
