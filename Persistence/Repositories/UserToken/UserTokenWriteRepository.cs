using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.UserToken;
using Persistence.Contexts;

namespace Persistence.Repositories.UserToken
{
    public class UserTokenWriteRepository : AuthWriteRepository<Domain.IdentityEntities.UserToken>, IUserTokenWriteRepository
    {
        public UserTokenWriteRepository(AuthDbContext context) : base(context)
        {
        }
    }
}
