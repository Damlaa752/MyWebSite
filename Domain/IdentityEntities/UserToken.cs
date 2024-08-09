using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.IdentityEntities
{
    public class UserToken : BaseEntity
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        // Foreign key
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
