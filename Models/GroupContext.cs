using Microsoft.EntityFrameworkCore;

namespace ProductApi.Models
{
    public class GroupContext : DbContext
    {
        public GroupContext(DbContextOptions<GroupContext> options)
            : base(options)
        {
        }

        public DbSet<GroupItem> GroupItem { get; set; }
    }
}