namespace Xp.Api.Application.Domain;

public class Customer
{
    public string Id { get; set; }

    public string FullName { get; set; }

    public string Telephone { get; set; }

    public Guid AddressId { get; set; }

    public virtual Address Address { get; set; }

    public string Email { get; set; }
}