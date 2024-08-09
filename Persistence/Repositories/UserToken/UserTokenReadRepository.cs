using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.User;
using Application.Repositories.UserToken;
using Persistence.Contexts;

namespace Persistence.Repositories.UserToken
{
    public class UserTokenReadRepository : AuthReadRepository<Domain.IdentityEntities.UserToken>, IUserTokenReadRepository
    {
        public UserTokenReadRepository(AuthDbContext context) : base(context)
        {
        }
    }
}
