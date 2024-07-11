using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

    
    public class ProductsController:BaseAPIController
    {
    private readonly IGenericRepository<Product> _productRepo;
    private readonly IGenericRepository<ProductBrand> _productBrandRepo;
    private readonly IGenericRepository<ProductType> _productTypeRepo;
    private readonly IMapper _mapper;

    public ProductsController(IGenericRepository<Product> productRepo,IGenericRepository<ProductBrand> productBrandRepo
        ,IGenericRepository<ProductType> productTypeRepo,IMapper mapper)
        {
        _productRepo = productRepo;
        _productBrandRepo = productBrandRepo;
        _productTypeRepo = productTypeRepo;
        _mapper = mapper;
    }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Pagination<Product>>>> GetProducts([FromQuery]ProductSpecParams productSpecParams)
        {
            var prodspec=new ProductWithTypeandBrand(productSpecParams); 

            var countSpec=new ProductWithFilterCountSpecification(productSpecParams);
            var totalcont= await _productRepo.Count(countSpec);
            var products=await _productRepo.GetListAsync(prodspec);

            var data=_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductDto>>(products);
            return Ok(new Pagination<ProductDto>(productSpecParams.PageIndex,productSpecParams.PageSize,totalcont,data));
        }
         [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var prodspec=new ProductWithTypeandBrand(id);
            var product=await _productRepo.GetEntityWithSpec(prodspec);
            return _mapper.Map<Product,ProductDto>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<Product>> GetProductBrands()
        {
            var productBrand=await _productBrandRepo.GetAsync();
            return Ok(productBrand);
        }
        [HttpGet("types")]
        public async Task<ActionResult<Product>> GetProductTypes()
        {
            var productType=await _productTypeRepo.GetAsync();
            return Ok(productType);
        }
        

    }
    

