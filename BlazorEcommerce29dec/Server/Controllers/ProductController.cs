﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorEcommerce29dec.Server.Data;

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

            //{
            //    Data = products
            //};

            var result = await _productService.GetProductsAsync();
            return Ok(result);
        }
    }
}