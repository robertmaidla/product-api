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
    public class StoreController : ControllerBase
    {
        private readonly StoreContext _context;
        public StoreController(StoreContext context) {
            _context = context;
            if (_context.StoreItems.Count() == 0) {
                string mockData = System.IO.File.ReadAllText("Data/StoreData.json");
                _context.StoreItems.AddRange(JsonConvert.DeserializeObject<IEnumerable<StoreItem>>(mockData));
                _context.SaveChanges();
            }
        }

        // GET: api/store
        // Return list of store items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreItem>>> GetStoreItems() {
            return await _context.StoreItems.ToListAsync();
        }

    }
}