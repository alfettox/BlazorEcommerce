
namespace BlazorEcommerce29dec.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int id)
        {
            var response = new ServiceResponse<Product>();

            //var product = await _context.Products.FindAsync(id);
            var product = await _context.Products
                .Include(p => p.Variants)
                .ThenInclude(v => v.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, this product doesn't exist";
            }
            else
            {
                response.Success = true;
                response.Data = product;

            }
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                //Data = await _context.Products.ToListAsync()
                Data = await _context.Products
                    .Include(p => p.Variants)
                    .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>>
            GetProductsByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                .Where(
                    p => p.Category.Url.ToLower()
                    .Equals(categoryUrl.ToLower()))
                    .Include(p => p.Variants)
                    .ToListAsync()

            };
            return response;
        }
    }
}
