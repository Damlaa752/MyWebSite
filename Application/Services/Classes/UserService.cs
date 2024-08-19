using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Repositories.User;
using Application.Services.Interface;
using Domain.Identity;

namespace Application.Services.Classes
{
    public class UserService : IUserService
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IUserReadRepository _userReadRepository;

        public UserService(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
        }

        public async Task<User> RegisterUserAsync(RegisterUserDto request)
        {
            var user = new User
            {
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Email = request.Email,
                Role = request.Role
            };

            // Kullanıcıyı veritabanına ekle
            var result = await _userWriteRepository.AddAsync(user);

            // Eğer ekleme başarılıysa kaydet ve kullanıcıyı geri döndür
            if (result)
            {
                await _userWriteRepository.SaveAsync();
                return user;
            }

            // Eklem başarısızsa null döndür
            return null;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            // Girilen int değerini string'e çeviriyoruz
            string idString = id.ToString();

            // String olarak dönüştürülmüş id ile veritabanından ilgili kullanıcıyı alıyoruz
            var user = await _userReadRepository.GetByIdAsync(idString);

            // Kullanıcı bulunamazsa null döndürüyoruz
            if (user == null)
            {
                return null;
            }

            // Kullanıcı bulunduysa bu kullanıcıyı döndürüyoruz
            return user;
        }
    }

}
