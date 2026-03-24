namespace SupplierService.Domain.Entities;

public class Supplier
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public Supplier(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}