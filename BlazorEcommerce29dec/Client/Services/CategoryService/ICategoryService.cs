namespace BlazorEcommerce29dec.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        List <Category> Categories { get; set; }
        Task GetCategories();


    }
}
