namespace SupplierService.Domain.Entities;

public class Delivery
{
    public Guid Id { get; private set; }
    public Guid SupplierId { get; private set; }
    public Guid ProductId { get; private set; }
    public DateTime Date { get; private set; }

    public Delivery(Guid supplierId, Guid productId)
    {
        Id = Guid.NewGuid();
        SupplierId = supplierId;
        ProductId = productId;
        Date = DateTime.UtcNow;
    }
}