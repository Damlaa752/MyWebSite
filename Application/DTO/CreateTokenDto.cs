﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CreateTokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int UserId { get; set; }
    }
}