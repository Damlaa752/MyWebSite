using Application.DTO;
using Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface
{
    public interface IUserTokenService
    {
        Task<UserToken> CreateTokenAsync(CreateTokenDto request);
        Task<IEnumerable<UserToken>> GetUserTokensAsync(int userId);
    }
}
