using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products=await _productRepository.GetProductsAsync();
            return Ok(products);
        }
         [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product=await _productRepository.GetProductByIdAsync(id);
            return Ok(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<Product>> GetProductBrands()
        {
            var productBrand=await _productRepository.GetProductBrandAsync();
            return Ok(productBrand);
        }
        [HttpGet("types")]
        public async Task<ActionResult<Product>> GetProductTypes()
        {
            var productType=await _productRepository.GetProductTypeAsync();
            return Ok(productType);
        }
        

    }
    

