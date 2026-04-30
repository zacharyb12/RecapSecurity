using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.AuthModels;

namespace RecapSecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _service) : ControllerBase
    {
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(RegisterRequest registerForm)
        {
            try
            {
                // appel du register
                string token = await _service.Register(registerForm);

                return Ok(token);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginForm)
        {
            try
            {
                string token = await _service.Login(loginForm);

                return Ok(token);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Update Password
        // demande l'ancien et le nouveau password
        // Repository : Mise à jour du mot de passe
        // Service : appel de la Mise à jour du mot de passe repository

    }
}
