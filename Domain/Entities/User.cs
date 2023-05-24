using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User:AppUser
    {
        //[InverseProperty("Location")]
        //public List<Order>? OrderLocation { get; set; }
        //[InverseProperty("Destination")]
        //public List<Order>? OrderDestination { get; set; }
    }
}
