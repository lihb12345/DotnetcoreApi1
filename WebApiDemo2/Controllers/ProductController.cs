using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo2.Domain;
using WebApiDemo2.Repository;

namespace WebApiDemo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAll();
            //var products = new List<Product>
            //{
            //    new Product{ Id=1, Name="Li1"},
            //    new Product{ Id=2, Name="Li2"}

            //};
            //return products;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                var createdProduct = _productRepository.Add(product);
                return Created($"product/{product.Id}",createdProduct);
            }
            catch (Exception e)
            {
                return ValidationProblem(e.ToString());
            }
        }
        [HttpPut]
        public IActionResult Update([FromBody] Product product)
        {
            try
            {
                var updatedProduct = _productRepository.Update(product);
                return Ok(updatedProduct);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var deleted = _productRepository.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
