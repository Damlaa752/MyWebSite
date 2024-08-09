using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.UserRole;
using Persistence.Contexts;

namespace Persistence.Repositories.UserRole
{
    public class UserRoleReadRepository : AuthReadRepository<Domain.IdentityEntities.UserRole>, IUserRoleReadRepository
    {
        public UserRoleReadRepository(AuthDbContext context) : base(context)
        {
        }
    }
}
