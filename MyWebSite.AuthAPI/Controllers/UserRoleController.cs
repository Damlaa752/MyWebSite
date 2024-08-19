using Application.DTO;
using Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebSite.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRole([FromBody] AddUserRoleDto request)
        {
            var role = await _userRoleService.AddRoleAsync(request);

            if (role == null)
            {
                return BadRequest(new { message = "Rol ekleme başarısız" });
            }

            return Ok(role);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserRoles(int userId)
        {
            var roles = await _userRoleService.GetUserRolesAsync(userId);
            if (roles == null || !roles.Any())
            {
                return NotFound(new { message = "Kullanıcı rolleri bulunamadı" });
            }

            return Ok(roles);
        }
    }
}
