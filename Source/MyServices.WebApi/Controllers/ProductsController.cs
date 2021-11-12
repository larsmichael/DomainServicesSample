namespace MyServices.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(IProductRepository productRepository)
        {
            _productService = new ProductService(productRepository);
        }

        [HttpGet()]
        [Route("all")]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(_productService.GetAll());
        }
        
    }
}
