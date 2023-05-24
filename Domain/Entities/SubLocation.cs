using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubLocation:BaseEntity
    {
        public string? Name { get; set; }     
        public int LocationId { get; set; }     
        public Location? Location { get; set; }     
    }
}
