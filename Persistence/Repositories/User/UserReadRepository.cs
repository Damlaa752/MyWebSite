using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.User;
using Persistence.Contexts;

namespace Persistence.Repositories.User
{
    public class UserReadRepository : AuthReadRepository<Domain.Identity.User>, IUserReadRepository
    {
        public UserReadRepository(AuthDbContext context) : base(context)
        {
        }
    }
}
