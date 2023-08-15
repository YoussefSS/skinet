using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // route will be /api/products/
    public class ProductsController : ControllerBase
    {
        public IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);
        }

        /* We will pass in id as a parameter
        * Note that if you try to pass in a string you'll get an error, this is the [ApiController] attribute doing validation work
        */
        [HttpGet("{id}")] // route will be /api/products/IDHERE
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id); // takes in a primary key
        }
    }
}