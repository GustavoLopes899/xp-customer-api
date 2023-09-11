using System.Text.RegularExpressions;
using Xp.Api.Application.Configuration.Database.Repositories;
using Xp.Api.Application.Domain;

namespace Xp.Api.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRespository;
    private const string EMAIL_PATTERN = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    private const string TELEPHONE_PATTERN = @"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$";

    public CustomerService(ICustomerRepository customerRespository)
    {
        _customerRespository = customerRespository;
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        ValidateCustomer(customer);
        Customer result = await _customerRespository.CreateAsync(customer);
        return result;
    }

    public async Task<Customer> GetByIdAsync(string id)
    {
        return await _customerRespository.GetByIdAsync(id);
    }

    public async Task<IList<Customer>> GetAllCustomers()
    {
        return await _customerRespository.GetAllAsync();
    }

    private static void ValidateCustomer(Customer customer)
    {
        if (customer == null)
        {
            throw new Exception($"The consumer is required");
        }

        bool emailIsValid = customer.Email != null && Regex.IsMatch(customer.Email, EMAIL_PATTERN);
        if (!emailIsValid)
        {
            throw new Exception($"The email format is incorrect: {customer.Email}");
        }

        bool telepohneIsValid = customer.Telephone != null && Regex.IsMatch(customer.Telephone, TELEPHONE_PATTERN);
        if (!telepohneIsValid)
        {
            throw new Exception($"The telephone format is incorrect: {customer.Telephone}");
        }
    }
}