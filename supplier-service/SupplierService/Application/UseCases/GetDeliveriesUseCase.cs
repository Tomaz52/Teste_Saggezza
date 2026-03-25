using SupplierService.Domain.Interfaces;
using SupplierService.Domain.Entities;
public class GetDeliveriesUseCase
{
    private readonly IDeliveryRepository _repository;

    public GetDeliveriesUseCase(IDeliveryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Delivery>> Execute()
    {
        return await _repository.GetAllAsync();
    }
}