using SupplierService.Domain.Entities;
using SupplierService.Domain.Interfaces;
using SupplierService.Application.DTOs;

namespace SupplierService.Application.UseCases;

public class CreateDeliveryUseCase
{
    private readonly IDeliveryRepository _deliveryRepo;
    private readonly ISupplierRepository _supplierRepo;
    private readonly IProductRepository _productRepo;

    public CreateDeliveryUseCase(
        IDeliveryRepository deliveryRepo,
        ISupplierRepository supplierRepo,
        IProductRepository productRepo)
    {
        _deliveryRepo = deliveryRepo;
        _supplierRepo = supplierRepo;
        _productRepo = productRepo;
    }

    public async Task Execute(CreateDeliveryDto dto)
    {
        var supplier = await _supplierRepo.GetByIdAsync(dto.SupplierId);
        var product = await _productRepo.GetByIdAsync(dto.ProductId);

        if (supplier == null || product == null)
            throw new Exception("Fornecedor ou produto não encontrado");

        var delivery = new Delivery(dto.SupplierId, dto.ProductId);

        await _deliveryRepo.AddAsync(delivery);
    }
}