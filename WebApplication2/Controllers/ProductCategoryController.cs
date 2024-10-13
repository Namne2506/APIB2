using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ProductCategoryRepos repos;

        public ProductCategoryController(ProductCategoryRepos repos)
        {
            this.repos = repos;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var productCategories = repos.GetAll();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(ProductCategory productCategory)
        {
            try
            {
                var data = repos.Create(productCategory);
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
                var FindProductCategory = repos.GetProductById(id);
                if (FindProductCategory == null)
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
        public IActionResult Put(ProductCategory productCategory)
        {
            try
            {

                var data = repos.Update(productCategory);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
