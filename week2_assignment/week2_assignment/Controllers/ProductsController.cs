using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace week2_assignment.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // Endpoint that fetches all products
        [HttpGet]
        [CustomAuthorize("Admin")]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        // Endpoint that fetches a specific product by ID
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }

        // Endpoint that creates a new product
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid request");
            }

            _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        // Endpoint that updates an existing product
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var existingProduct = _productService.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound("Product not found");
            }
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;

            _productService.UpdateProduct(id, existingProduct);

            return NoContent();
        }

        // Endpoint that deletes a specific product by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existingProduct = _productService.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound("Product not found");
            }

            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
