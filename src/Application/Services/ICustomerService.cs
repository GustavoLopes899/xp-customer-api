using Xp.Api.Application.Domain;

namespace Xp.Api.Application.Services;

public interface ICustomerService
{
    Task<Customer> CreateAsync(Customer customer);

    Task<Customer> GetByIdAsync(string id);

    Task<IList<Customer>> GetAllCustomers();
}