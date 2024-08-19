using Application.DTO;
using Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebSite.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTokenController : ControllerBase
    {
        private readonly IUserTokenService _userTokenService;

        public UserTokenController(IUserTokenService userTokenService)
        {
            _userTokenService = userTokenService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateToken([FromBody] CreateTokenDto request)
        {
            var token = await _userTokenService.CreateTokenAsync(request);

            if (token == null)
            {
                return BadRequest(new { message = "Token oluşturma başarısız" });
            }

            return Ok(token);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserTokens(int userId)
        {
            var tokens = await _userTokenService.GetUserTokensAsync(userId);
            if (tokens == null || !tokens.Any())
            {
                return NotFound(new { message = "Kullanıcı tokenları bulunamadı" });
            }

            return Ok(tokens);
        }
    }
}
