using DIRSHotelManagement.Interfaces;
using DIRSHotelManagement.Models;
using DIRSHotelManagement.Service;
using Microsoft.AspNetCore.Mvc;

namespace DIRSHotelManagement.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string categoryName = null)
        {
            var products = await _productRepository.GetAllAsync(page, pageSize, categoryName);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            await _productRepository.AddAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, [FromBody] Product product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.CategoryName = product.CategoryName;
            existingProduct.Capacity = product.Capacity; // Update capacity
            existingProduct.PricePerNight = product.PricePerNight;

            await _productRepository.UpdateAsync(id, existingProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            await _productRepository.DeleteAsync(id);
            return NoContent();
        }
    }


}
