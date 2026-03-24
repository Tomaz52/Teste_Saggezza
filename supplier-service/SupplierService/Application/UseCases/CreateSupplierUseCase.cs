using SupplierService.Domain.Entities;
using SupplierService.Domain.Interfaces;
using SupplierService.Application.DTOs;

namespace SupplierService.Application.UseCases;

public class CreateSupplierUseCase
{
    private readonly ISupplierRepository _repository;

    public CreateSupplierUseCase(ISupplierRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(CreateSupplierDto dto)
    {
        var supplier = new Supplier(dto.Name);
        await _repository.AddAsync(supplier);
    }
}