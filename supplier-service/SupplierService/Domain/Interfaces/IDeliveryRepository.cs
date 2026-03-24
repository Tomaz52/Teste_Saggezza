using SupplierService.Domain.Entities;

namespace SupplierService.Domain.Interfaces;

public interface IDeliveryRepository
{
    Task AddAsync(Delivery delivery);
    Task<List<Delivery>> GetAllAsync();
}