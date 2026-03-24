using SupplierService.Domain.Entities;

namespace SupplierService.Domain.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
}