using Xp.Api.Application.Domain;

namespace Xp.Api.Application.Configuration.Database.Repositories;

public interface ICustomerRepository
{
    Task<Customer> GetByIdAsync(string id);

    Task<IList<Customer>> GetAllAsync();

    Task<Customer> CreateAsync(Customer customer);

    Task<Customer> UpdateAsync(Customer customer);

    Task DeleteAsync(Customer customer);
}