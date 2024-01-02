
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

        public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchedText)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await FindProductBySearchText(searchedText)

            };
            return response;
        }

        private async Task<List<Product>> FindProductBySearchText(string searchedText)
        {
            return await _context.Products
                                .Where(p => p.Title.ToLower().Contains(searchedText.ToLower())
                                || p.Description.ToLower().Contains(searchedText.ToLower()))
                                .Include(p => p.Variants)
                                .ToListAsync();
        }

        public async Task<ServiceResponse<List<string>>>
            GetProductSearchSuggestions(string searchedText)
        {
            var products = await FindProductBySearchText(searchedText);
            List<string> result = new List<string>();

            foreach (var product in products)
            {
                if (product.Title.Contains(searchedText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if (product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));
                    foreach (var word in words)
                    {
                        if (word.Contains(searchedText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }

                    }
                }
            }


            return new ServiceResponse<List<string>> { Data = result };
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>
            {

                Data = await _context.Products
                .Where(product => product.Featured)
                .Include(product => product.Variants)
                .ToListAsync()
            };

            return response;
        }
    }

}
