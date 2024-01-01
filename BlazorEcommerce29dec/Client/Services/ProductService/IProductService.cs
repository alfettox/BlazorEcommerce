namespace BlazorEcommerce29dec.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;

        List<Product> products { get; set; }

        //Task GetProducts();
        Task GetProducts(string? categoryUrl = null); //if we dont have any category retrieve all

        Task <ServiceResponse<Product>> GetProduct(int productId);
    }
}
