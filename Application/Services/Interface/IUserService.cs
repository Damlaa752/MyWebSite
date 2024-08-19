using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Services.Interface
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(RegisterUserDto request);
        Task<User> GetUserByIdAsync(int id);
    }
}
