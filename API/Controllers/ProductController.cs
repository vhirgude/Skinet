using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products=_context.Products.ToList();
            return products;
        }
         [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product=_context.Products.Find(id);
            return product;
        }
        [HttpPost]
        public ActionResult<Product> AddProduct([FromBody]Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges(); 

            return product;         
        }

    }
    

