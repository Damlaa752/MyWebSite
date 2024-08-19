using Application.DTO;
using Application.Services.Interface;
using Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.UserToken;

namespace Application.Services.Classes
{
    public class UserTokenService : IUserTokenService
    {
        private readonly IUserTokenWriteRepository _userTokenWriteRepository;
        private readonly IUserTokenReadRepository _userTokenReadRepository;

        public UserTokenService(IUserTokenWriteRepository userTokenWriteRepository)
        {
            _userTokenWriteRepository = userTokenWriteRepository;
        }

        public async Task<UserToken> CreateTokenAsync(CreateTokenDto request)
        {
            var token = new UserToken
            {
                Token = request.Token,
                Expiration = request.Expiration,
                UserId = request.UserId
            };

            // Token'i veritabanına ekle
            var result = await _userTokenWriteRepository.AddAsync(token);

            // Eğer ekleme başarılıysa kaydet ve token nesnesini geri döndür
            if (result)
            {
                await _userTokenWriteRepository.SaveAsync();
                return token;
            }

            // Eklem başarısızsa null döndür
            return null;
        }

        public async Task<IEnumerable<UserToken>> GetUserTokensAsync(int userId)
        {
            // Girilen int değerini string'e çeviriyoruz
            string userIdString = userId.ToString();

            // String olarak dönüştürülmüş userId ile veritabanından ilgili UserToken'ları alıyoruz
            IEnumerable<UserToken> tokens = await _userTokenReadRepository.GetByIdAsync(userIdString);

            // Eğer tokenlar null ise, boş bir liste döndürüyoruz
            if (tokens == null || !tokens.Any())
            {
                return Enumerable.Empty<UserToken>();
            }

            // Sonuçları geri döndürüyoruz
            return tokens;
        }
    }
}
