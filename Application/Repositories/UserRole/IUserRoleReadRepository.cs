using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.UserRole
{
    public interface IUserRoleReadRepository : IAuthReadRepository<Domain.IdentityEntities.UserRole>
    {
        Task<IEnumerable<Domain.IdentityEntities.UserRole>> GetByIdAsync(string userId);
    }
}
