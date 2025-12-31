using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Basee.Models;

namespace Basee.Data
{
    public class BaseeContext : DbContext
    {
        public BaseeContext (DbContextOptions<BaseeContext> options)
            : base(options)
        {
        }

        public DbSet<Basee.Models.registration> registration { get; set; } = default!;
    }
}
