using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.User;

namespace Persistence.Repositories.User
{
    public class UserWriteRepository : AuthWriteRepository<Domain.Identity.User>, IUserWriteRepository
    {
        public UserWriteRepository(AuthDbContext context) : base(context)
        {
        }
    }
}
