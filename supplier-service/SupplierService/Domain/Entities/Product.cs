namespace SupplierService.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public Product(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}