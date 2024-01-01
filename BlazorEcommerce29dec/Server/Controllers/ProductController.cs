using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce29dec.Server.Controllers
{
    [Route("api/[controller]")] //api/product
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly DataContext _context;
        private readonly IProductService _productService;

        //public ProductController(DataContext context)
        public ProductController(IProductService productService)
        {
            _productService = productService;
            //_context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>>
            GetProducts()
        {
            //var products = await _context.Products.ToListAsync();
            //var response = new ServiceResponse<List<Product>>()
            //{Data = products//};
            var result = await _productService.GetProductsAsync();
            return Ok(result);
        }

        [HttpGet("{productId}")]
        //[Route("{id}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
        {
            var result = await _productService.GetProductAsync(productId);
            return Ok(result);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>>
            GetProductsByCategory(string categoryUrl)
        {
            var result = await _productService.GetProductsByCategory(categoryUrl);
            return Ok(result);
        }

        [HttpGet("search/{searchedText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> SearchProducts
            (string searchedText)
        {
            var result = await _productService.SearchProducts(searchedText);
            return Ok(result);
        }

    }
}