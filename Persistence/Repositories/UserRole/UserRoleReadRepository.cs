using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.UserRole;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence;  // AuthDbContext'in tanımlandığı namespace


namespace Persistence.Repositories.UserRole
{
    public class UserRoleReadRepository : AuthReadRepository<Domain.IdentityEntities.UserRole>, IUserRoleReadRepository
    {
        private readonly AuthDbContext _context;

        public UserRoleReadRepository(AuthDbContext context) : base(context)
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
