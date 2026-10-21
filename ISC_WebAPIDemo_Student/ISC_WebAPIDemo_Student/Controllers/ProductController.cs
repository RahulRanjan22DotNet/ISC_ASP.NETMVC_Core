using ISC_WebAPIDemo_Student.Data;
using ISC_WebAPIDemo_Student.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISC_WebAPIDemo_Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProductDTO1 prod)
        {
            Product _prod = new Product();
            _prod.ProductName = prod.ProductName;
            _prod.ProductDescription = prod.ProductDescription;
            _prod.ProductCategory = prod.ProductCategory;
            _prod.PurchasePrice = prod.PurchasePrice;
            _prod.SalePrice = prod.SalePrice;
            _prod.CreatedOn = DateTime.Now;
            
            context.Product.Add(_prod);
            var result = await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO2>>> Get()
        {
            var prodList = await context.Product.ToListAsync();
            List<ProductDTO2> list = new List<ProductDTO2>();
            foreach (var item in prodList)
            {
                ProductDTO2 p = new ProductDTO2();
                p.Id = item.Id;
                p.ProductName = item.ProductName;
                p.ProductDescription = item.ProductDescription;
                p.ProductCategory = item.ProductCategory;
                p.SalePrice = item.SalePrice;
                list.Add(p);
            }
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO2>> Get(int? id)
        {
            var product = await context.Product.FirstOrDefaultAsync(x => x.Id == id);
            ProductDTO2 prod = new ProductDTO2();
            if(prod != null)
            {
                prod.Id = product.Id;
                prod.ProductName = product.ProductName;
                prod.ProductDescription = product.ProductDescription;
                prod.ProductCategory = product.ProductCategory;
                prod.SalePrice = product.SalePrice;
            }
            return Ok(prod);
        }
    }
}
