using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductStoreAPI.Models.Business.Product;
using ProductStoreAPI.Repository.Repositories.Product;
using System.Threading.Tasks;

namespace ProductStoreAPI.Host.Controllers
{
    [Authorize]
    public class ProductController(
        IProductRepository productRepository)
        : ApiBaseController
    {
        [HttpGet("All")]
        public async Task<IActionResult> GetAll(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 2)
        {
            var products = await productRepository.GetAllProductsAsync(
                pageNumber, pageSize);

            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById(
            long productId)
        {
            var product = await productRepository.GetProductByIdAsync(
                productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "SiteAdministrator")]
        public async Task<IActionResult> Post(
            [FromBody] Product productObj)
        {
            var isSuccess = await productRepository.CreateProductAsync(
                productObj);

            if (!isSuccess)
            {
                return BadRequest();
            }

            return Ok(isSuccess);
        }

        [HttpPut("Update")]
        [Authorize(Roles = "SiteAdministrator")]
        public async Task<IActionResult> Put(
            [FromBody] Product productObj)
        {
            await productRepository.UpdateProductAsync(
                productObj);

            return Ok();
        }

        [HttpDelete("{productId}")]
        [Authorize(Roles = "SiteAdministrator")]
        public async Task<IActionResult> Delete(
            [FromRoute] long productId)
        {
            var isDeleted = await productRepository.DeleteProductAsync(
                productId);

            if (!isDeleted)
            {
                return BadRequest();
            }

            return Ok(isDeleted);
        }
    }
}