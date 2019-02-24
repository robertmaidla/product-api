using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductApi.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly GroupContext _context;
        public GroupController(GroupContext context) {
            _context = context;
            if (_context.GroupItem.Count() == 0) {
                string mockData = System.IO.File.ReadAllText("Data/GroupData.json");
                GroupItem masterNode = JsonConvert.DeserializeObject<GroupItem>(mockData);
                _context.Add(masterNode);
                _context.SaveChanges();
            }
        }

        // GET: api/group
        // Return the master group
        [HttpGet]
        public async Task<ActionResult<GroupItem>> GetMasterGroup() {
            return await _context.GroupItem.FindAsync((long)1);
        }

    }
}