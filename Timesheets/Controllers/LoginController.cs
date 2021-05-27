using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;
using Timesheets.Models.Dto.Authentication;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginManager _loginManager;
        private readonly IRefreshTokenRepo _refreshTokenRepo;
        private readonly IUserManager _userManager;

        public LoginController(ILoginManager loginManager, IUserManager userManager,
            IRefreshTokenRepo refreshTokenRepo)
        {
            _loginManager = loginManager;
            _userManager = userManager;
            _refreshTokenRepo = refreshTokenRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.GetUser(request);

            if (user == null) return Unauthorized();

            var loginResponse = _loginManager.Authenticate(user);

            return Ok(loginResponse);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var token = await _refreshTokenRepo.GetItem(request.Token);
            if (token == null) return Unauthorized();
            
            var user = await _userManager.GetItem(token.UserId);
            if (user == null) return Unauthorized();

            var loginResponse = _loginManager.Authenticate(user);

            return Ok(loginResponse);
        }
    }
}