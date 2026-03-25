using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AuthService.Infrastructure.Persistence
{
    public class SupplierDbContext : DbContext
    {
        public SupplierDbContext(DbContextOptions<SupplierDbContext> options)
            : base(options)
        {
        }

        //public DbSet<Supplier> Suppliers { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Delivery> Deliveries { get; set; }
    }
}
