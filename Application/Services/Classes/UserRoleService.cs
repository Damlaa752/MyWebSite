using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Application.DTO;
using Application.Repositories.UserRole;
using Application.Services.Interface;
using Domain.IdentityEntities;

namespace Application.Services.Classes
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleWriteRepository _userRoleWriteRepository;
        private readonly IUserRoleReadRepository _userRoleReadRepository;

        public UserRoleService(IUserRoleWriteRepository userRoleWriteRepository, IUserRoleReadRepository userRoleReadRepository)
        {
            _userRoleWriteRepository = userRoleWriteRepository;
            _userRoleReadRepository = userRoleReadRepository;
        }

        public async Task<UserRole> AddRoleAsync(AddUserRoleDto request)
        {
            var role = new UserRole
            {
                RoleName = request.RoleName,
                UserId = request.UserId
            };

            // Rolü veritabanına ekle
            var result = await _userRoleWriteRepository.AddAsync(role);

            // Eğer ekleme başarılıysa kaydet ve rol nesnesini geri döndür
            if (result)
            {
                await _userRoleWriteRepository.SaveAsync();
                return role;
            }

            // Eklem başarısızsa null döndür
            return null;
        }

        public async Task<IEnumerable<UserRole>> GetUserRolesAsync(int userId)
        {
            //// Girilen int değerini string'e çeviriyoruz
            //string userIdString = userId.ToString();

            //// String olarak dönüştürülmüş userId ile veritabanından ilgili UserRole'leri alıyoruz
            //IEnumerable<UserRole> roles = await _userRoleReadRepository.GetByIdAsync(userIdString);

            //// Eğer sonuç null ise veya boş ise, kullanıcıya bilgilendirici bir mesajla bir liste döndür
            //if (roles == null || !roles.Any())
            //{
            //    return new List<UserRole> { new UserRole { RoleName = "Böyle bir rol yok." } };
            //}

            //// Sonuçları geri döndür
            //return roles;

            string userIdString = userId.ToString();
            return await _userRoleReadRepository.GetByIdAsync(userIdString);
        }

    }
}
