using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Models.AuthModels;

namespace RecapSecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("RateLimiteHundred")]
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


        [HttpPut("updatepassword")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordRequest request)
        {
            try
            {
                bool result = await _service.UpdatePassword(request);

                if(result)
                {
                    return NoContent();
                }

                return BadRequest("L'opération n'as pas pu être executée");
            }
            catch (UnauthorizedAccessException ex)
            {
                return BadRequest("Les informations sont incorrectes");
            }
            catch (Exception ex) 
            {
                return BadRequest("Une erreur est survenue veuillez réessayer !");
            }

    }
}
}
