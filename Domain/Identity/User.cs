using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Identity
{
    public class User : BaseEntity
    {
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(255)]
        public string PasswordHash { get; set; }
        [StringLength(50)]
        public string Role { get; set; }
    }
}
