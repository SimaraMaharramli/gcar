﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.DTOs.Account
{
    public class ChangePasswordDto
    {
        public string? CurrentPass { get; set; }
        public string? NewPass { get; set; }
        public string? ReNewPass { get; set; }
    }
}
