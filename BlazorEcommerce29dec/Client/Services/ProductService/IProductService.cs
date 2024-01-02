namespace BlazorEcommerce29dec.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;
        string Message { get; set; }

        List<Product> Products { get; set; }

        //Task GetProducts();
        Task GetProducts(string? categoryUrl = null); //if we dont have any category retrieve all

        Task <ServiceResponse<Product>> GetProduct(int productId);

        Task SearchProducts(string searchedText);

        Task <List<string>> GetProductSearchSuggestions(string searchedText);
    }
}
