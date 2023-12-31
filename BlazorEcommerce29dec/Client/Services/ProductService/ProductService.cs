﻿
using System.Net.Http.Json;

namespace BlazorEcommerce29dec.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public event Action ProductsChanged;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public List<Product> Products { get; set; } = new List<Product>();
        
        public string Message { get; set; } = "LOADING PRODUCTS";

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync
                <ServiceResponse<Product>>($"api/product/{productId}");
            return result;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result =
                categoryUrl == null ?
                await _http.GetFromJsonAsync <ServiceResponse<List<Product>>>("api/product/featured") :
                await _http.GetFromJsonAsync <ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}") ;
            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }
            ProductsChanged.Invoke();
        }

        public async  Task SearchProducts(string searchedText)
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<Product>>>
                ($"api/product/search/{searchedText}");
            if(result != null && result.Data != null)
            {
                Products = result.Data;
            }
            if(Products.Count == 0 )
            {
                Message = "NO PRODUCTS FOUND";
            }
            ProductsChanged?.Invoke();

        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchedText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>
                ($"api/product/searchsuggestions/{searchedText}");
            return result.Data;
        }
    }
}
