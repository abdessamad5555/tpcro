using Microsoft.EntityFrameworkCore;
using Basee.Models;

namespace Basee.Data
{
    public class BaseeContext : DbContext
    {
        public BaseeContext(DbContextOptions<BaseeContext> options)
            : base(options)
        {
        }

        public DbSet<registration> registration { get; set; }
    }
}
