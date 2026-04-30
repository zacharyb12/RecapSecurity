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

        [HttpGet]
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


        /*


        // Update

        // Delete

        // Update Role

         */
    }
}
