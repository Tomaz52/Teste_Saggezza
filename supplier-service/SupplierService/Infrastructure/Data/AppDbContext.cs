using Microsoft.EntityFrameworkCore;
using SupplierService.Domain.Entities;

namespace SupplierService.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}