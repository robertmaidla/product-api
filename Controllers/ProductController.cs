using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductApi.Models;
using Newtonsoft.Json;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;
        public ProductController(ProductContext context) {
            _context = context;
            if (_context.ProductItems.Count() == 0) {
                string mockData = System.IO.File.ReadAllText("Data/ProductData.json");
                _context.ProductItems.AddRange(JsonConvert.DeserializeObject<IEnumerable<ProductItem>>(mockData));
                _context.SaveChanges();
            }
        }

        // GET: api/product
        // Return a list of all the products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductItem>>> GetProductItems() {
            return await _context.ProductItems.ToListAsync();
        }

        // GET: api/product/1
        // Return product by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductItem>> GetProductItem(long id) {
            var product = await _context.ProductItems.FindAsync(id);
            if (product == null) {
                return NotFound();
            }
            return product;
        }

        // POST: api/product
        // Add new product to products db
        [HttpPost]
        public async Task<ActionResult<ProductItem>> PostProductItem(ProductItem item) {
            // Validation & calculation
            if (item.ValidateNewItem()) {
                item.CalculateMissingParameters();
                _context.ProductItems.Add(item);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProductItem), new ProductItem{ Id = item.Id }, item);
            } else {
                return UnprocessableEntity();
            }
        }
    }
}