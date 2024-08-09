using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.UserRole;

namespace Persistence.Repositories.UserRole
{
    public class UserRoleWriteRepository : AuthWriteRepository<Domain.IdentityEntities.UserRole>, IUserRoleWriteRepository
    {
        public UserRoleWriteRepository(AuthDbContext context) : base(context)
        {
        }
    }
}
