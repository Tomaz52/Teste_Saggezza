namespace SupplierService.Application.DTOs;

public class CreateDeliveryDto
{
    public Guid SupplierId { get; set; }
    public Guid ProductId { get; set; }
}