using Application.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.UserModels;

namespace RecapSecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _service) : ControllerBase
    {

        // verbe utilisé
        [HttpGet]
        // réponses prévu par la route
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async  Task<ActionResult> GetAll()
        {
            try
            {
                IEnumerable<UserDTOs> result = await _service.GetAll();

                if(!result.Any())
                {
                    return NoContent();
                }

                return Ok(result);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {

                UserDTOs? u = await _service.GetByIdAsync(id);

                if(u == null)
                {
                    return NotFound();
                }

                return Ok(u);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(UserDTOs userUpdated)
        {
            try
            {
                bool result = await _service.UpdateAsync(userUpdated);

                if(!result)
                {
                    return NotFound();
                }

                return NoContent();

            }catch(Exception ex)
            {
                return BadRequest($"Une erreur est survenue : {ex.Message}");
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {

                bool result = await _service.DeleteAsync(id);

                if(!result)
                {
                    return NotFound();
                }

                return NoContent();

            }catch(Exception ex)
            {
                return BadRequest($"Une erreur est survenue : {ex.Message}");
            }
        }

        [HttpPut("update-role")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateRole(int id, string role)
        {
            try
            {
                bool result = await _service.UpdateRole(id,role);
                if(!result)
                {
                    return NotFound();
                }

                return NoContent();

            }catch(Exception ex)
            {
                return BadRequest($"Une erreur est survenue : {ex.Message}");
            }
        }
    }
}
