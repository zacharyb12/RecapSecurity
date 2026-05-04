using Application.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ProductModels;

namespace RecapSecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService _service) : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductLightDTOs>>> GetProducts()
        {

            try
            {

                IEnumerable<ProductLightDTOs> datas = await _service.GetAllAsync();

                if (datas.Count() < 1)
                {
                    throw new NullReferenceException("Aucune données à afficher");
                }

                return Ok(datas);

            }catch(NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch( Exception ex)
            {
                return BadRequest($"Une erreur est survenue : {ex.Message}");
            }
        }

        [HttpGet("byUser")]
        public async Task<IActionResult> GetAllByUser(int id)
        {
            try
            {
                IEnumerable<ProductLightDTOs> datas = await _service.GetAllByUserIdAsync(id);

                if(datas.Count() < 1)
                {
                    throw new NullReferenceException("Aucune données à afficher");
                }
                return Ok(datas);

            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Une erreur est survenue : {ex.Message}");
            }
        }

        // GetById : Get
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetById(int id)
        {

            try
            {
                // Appel du service
                ProductLightDTOs? p = await _service.GetByIdAsync(id);
                
                if(p == null)
                {
                    return NotFound("Aucun produit avec cet identifiant !");
                }

                return Ok(p);

            }catch(Exception ex)
            {
                return BadRequest($"Une erreur est survenue : {ex.Message}");
            }
        }


        // Create : Post
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(CreateProductDTOs newProduct)
        {

            try
            {
                // Appel du service
                bool result = await _service.CreateAsync(newProduct);

                if(!result)
                {
                    return NotFound("Le produit n'as pas pu être crée !");
                }

                return NoContent();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update : Put
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(UpdateProductDtos updatedProduct)
        {

            try
            {

                bool result = await _service.UpdateAsync(updatedProduct);
                if(!result)
                {
                    return NotFound();
                }

                return NoContent();
            
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete : Delete
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                // Appel du service
                bool result = await _service.DeleteAsync(id);
                if(!result)
                {
                    return NotFound();
                }

                return NoContent();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
