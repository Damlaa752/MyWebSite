using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories.User
{
    public class UserReadRepository : AuthReadRepository<Domain.Identity.User>, IUserReadRepository
    {
        private readonly AuthDbContext _context;
        public UserReadRepository(AuthDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Domain.IdentityEntities.UserRole>> GetByIdAsync(string userId)
        {
            // Veritabanından userId'ye göre UserRole'leri alıyoruz
            return await _context.UserRoles
                .Where(ur => ur.UserId.ToString() == userId)
                .ToListAsync();
        }
    }
}
