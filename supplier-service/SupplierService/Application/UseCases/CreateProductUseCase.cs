using SupplierService.Domain.Entities;
using SupplierService.Domain.Interfaces;
using SupplierService.Application.DTOs;

namespace SupplierService.Application.UseCases;

public class CreateProductUseCase
{
    private readonly IProductRepository _repository;

    public CreateProductUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(CreateProductDto dto)
    {
        var product = new Product(dto.Name);
        await _repository.AddAsync(product);
    }
}