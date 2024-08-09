using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.IdentityEntities
{
    public class UserRole: BaseEntity
    {
        public string RoleName { get; set; }

        // Foreign key
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
