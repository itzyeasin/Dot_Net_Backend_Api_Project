using BackendAPI_Assignment.Data;
using BackendAPI_Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext dbContext;

        public ProductsController(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult PostProductsDB(AddProductDB addProductDB)
        {
            var productEntity = new Product()
            {
                ProductID = addProductDB.ProductID,
                Name = addProductDB.Name,
                Description = addProductDB.Description,
                Price = addProductDB.Price,
                Quantity = addProductDB.Quantity,
            };

            dbContext.Products.Add(productEntity);
            dbContext.SaveChanges();

            return Ok(productEntity);
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult GetProductsDB()
        {
            var allMyStoreProducts = dbContext.Products.ToList();

            return Ok(allMyStoreProducts);
        }

        // GET: api/Products/id
        [HttpGet]
        [Route("{ProductID:int}")]
        public IActionResult GetProductsById(int ProductID)
        {
            var product = dbContext.Products.Find(ProductID);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/id
        [HttpPut]
        [Route("{ProductID:int}")]
        public IActionResult PutProductsDB(int ProductID, PutProductsDB putProductsDB)
        {
            // Find the existing product
            var product = dbContext.Products.Find(ProductID);

            if (product == null)
            {
                return NotFound();
            }
            
            product.Name = putProductsDB.Name;
            product.Description = putProductsDB.Description;
            product.Price = putProductsDB.Price;
            product.Quantity = putProductsDB.Quantity;

            dbContext.SaveChanges();
            return Ok(product);
        }

        // DELETE: api/Products/id
        [HttpDelete]
        [Route("{ProductID:int}")]
        public IActionResult DeleteProductsDB(int ProductID)
        {
            var product = dbContext.Products.Find(ProductID);

            if (product == null)
            {
                return NotFound();
            }

            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return Ok("Deleted");
        }
    }
}
