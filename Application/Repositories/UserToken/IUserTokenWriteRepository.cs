using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.UserToken
{
    public interface IUserTokenWriteRepository : IAuthWriteRepository<Domain.IdentityEntities.UserToken>
    {
    }
}
