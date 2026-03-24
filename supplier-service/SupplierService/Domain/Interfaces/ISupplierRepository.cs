using SupplierService.Domain.Entities;

namespace SupplierService.Domain.Interfaces;

public interface ISupplierRepository
{
    Task AddAsync(Supplier supplier);
    Task<List<Supplier>> GetAllAsync();
    Task<Supplier?> GetByIdAsync(Guid id);
}