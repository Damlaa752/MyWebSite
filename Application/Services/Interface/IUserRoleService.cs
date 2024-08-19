using Application.DTO;
using Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface
{
    public interface IUserRoleService
    {
        Task<UserRole> AddRoleAsync(AddUserRoleDto request);
        Task<IEnumerable<UserRole>> GetUserRolesAsync(int userId);
    }
}
