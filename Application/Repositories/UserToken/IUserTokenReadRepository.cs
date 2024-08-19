using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.UserToken
{
    public interface IUserTokenReadRepository : IAuthReadRepository<Domain.IdentityEntities.UserToken>
    {
        Task<IEnumerable<Domain.IdentityEntities.UserToken>> GetByIdAsync(string userId);
    }
}
