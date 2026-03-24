namespace SupplierService.Domain.ValueObjects;

public class Email
{
    public string Address { get; private set; }

    public Email(string address)
    {
        if (string.IsNullOrWhiteSpace(address) || !address.Contains("@"))
            throw new ArgumentException("Email inválido");

        Address = address;
    }

    public override string ToString() => Address;
}