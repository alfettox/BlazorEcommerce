﻿namespace BlazorEcommerce29dec.Client.Services.ProductService
{
    public interface IProductService
    {
        List<Product> products { get; set; }

        Task GetProducts();

        Task <ServiceResponse<Product>> GetProduct(int productId);
    }
}