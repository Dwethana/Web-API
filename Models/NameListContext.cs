using Microsoft.EntityFrameworkCore;

namespace NameListApi.Models
{
    public class NameListContext : DbContext
    {
        public NameListContext(DbContextOptions<NameListContext> options)
            : base(options)
        {
        }

        public DbSet<NameListItem> NameListItems { get; set; }
    }
}