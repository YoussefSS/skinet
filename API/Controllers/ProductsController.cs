using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // route will be /api/products/
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "this will be a list of products!!!";
        }

        /* We will pass in id as a parameter
        * Note that if you try to pass in a string you'll get an error, this is the [ApiController] attribute doing validation work
        */
        [HttpGet("{id}")] // route will be /api/products/IDHERE
        public string GetProduct(int id)
        {
            return "this will be a product";
        }
    }
}