using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.User;
using Application.Repositories.UserToken;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories.UserToken
{
    public class UserTokenReadRepository : AuthReadRepository<Domain.IdentityEntities.UserToken>, IUserTokenReadRepository
    {
        private readonly AuthDbContext _context;
        public UserTokenReadRepository(AuthDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Domain.IdentityEntities.UserToken>> GetByIdAsync(string userTokenId)
        {
            // Veritabanından userId'ye göre UserRole'leri alıyoruz
            return await _context.UserTokens
                .Where(ur => ur.UserId.ToString() == userTokenId)
                .ToListAsync();
        }
    }
}
