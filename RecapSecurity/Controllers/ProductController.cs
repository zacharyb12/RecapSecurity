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
           public static List<Product> datas = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "product 1",
                    Description = "description 1",
                    Price = 15.89,
                    ImageUrl = "image 1"
                },
                new Product
                {
                    Id = 2,
                    Name = "product 2",
                    Description = "description 2",
                    Price = 158.9,
                    ImageUrl = "image 2"
                }
            };

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {

            try
            {
                // Appel du service

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

        // GetById : Get
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> GetById(int id)
        {

            try
            {
                // Appel du service
                Product? p = datas.FirstOrDefault(p => p.Id == id);
                
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
                Product? productAdded = datas.FirstOrDefault(p => p.Name == newProduct.Name);

                if(productAdded == null)
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
        public async Task<ActionResult> Update(Product updatedProduct)
        {

            try
            {

                // Appel du service

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
                Product? productToDelete = datas.FirstOrDefault(p => p.Id == id); // recuperation lié à la liste
                
                if(productToDelete == null)
                {
                    return NotFound();
                }

                datas.Remove(productToDelete); // suppression lié à la liste

                return NoContent();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
