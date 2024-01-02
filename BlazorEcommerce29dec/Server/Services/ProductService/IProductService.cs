namespace BlazorEcommerce29dec.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();

        Task<ServiceResponse<Product>> GetProductAsync(int id);

        Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl);

        Task<ServiceResponse<List<Product>>> SearchProducts(string searchedText);

        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchedText);

        Task<ServiceResponse<List<Product>>> GetFeaturedProducts();
    }
}
