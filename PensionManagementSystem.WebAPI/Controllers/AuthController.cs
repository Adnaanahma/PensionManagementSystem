using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PensionManagementSystem.Application.ViewModels;
using PensionManagementSystem.Domain.Services;

namespace PensionManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        /// <summary>
        /// Employer Login with Reg No
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] EmployerLoginModel model)
        {
            try
            {

                var tokens = await _authService.LoginEmployerAsync(model);
                return Ok(tokens);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// RefreshToken Endpoint
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> Refresh([FromBody] string refreshToken)
        {
            var tokens = await _authService.RefreshTokenAsync(refreshToken);
            return Ok(tokens);
        }
    }

}
