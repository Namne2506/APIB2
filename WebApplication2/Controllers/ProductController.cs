using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepos repos;

        public ProductController(ProductRepos repos)
        {
            this.repos = repos;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var products = repos.GetAll();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                var data = repos.Create(product);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var author = repos.GetProductById(id);
                if (author == null)
                {
                    return NotFound();
                }

                var deleted = repos.Delete(id);
                if (!deleted)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Product product)
        {
            try
            {
                
                var data = repos.Update(product);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
