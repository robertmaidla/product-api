using Microsoft.EntityFrameworkCore;

namespace ProductApi.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public DbSet<StoreItem> StoreItems { get; set; }
    }
}