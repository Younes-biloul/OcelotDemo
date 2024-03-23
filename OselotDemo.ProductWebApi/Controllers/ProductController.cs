using Microsoft.AspNetCore.Mvc;
using OselotDemo.ProductWebApi.models;
using System.Collections.Generic;
namespace OselotDemo.ProductWebApi.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly List<Product> _products = new List<Product>();

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            
             _products.Add(product);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _products.Find(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var index = _products.FindIndex(p => p.ProductId == id);
            if (index == -1)
            {
                return NotFound();
            }
            _products[index] = updatedProduct;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _products.Find(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            _products.Remove(product);
            return NoContent();
        }
    }

}
