using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.DTOs.Account
{
    public class RegisterDriverDto
    {
        public int GolfCarId { get; set; }
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
