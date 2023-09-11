using NSubstitute;
using Xp.Api.Application.Configuration.Database.Repositories;
using Xp.Api.Application.Domain;
using Xp.Api.Application.Services;
using Xunit;

namespace Xp.Api.Application_Test;

public class CustomerTests
{
    private readonly Customer _customer;
    private readonly ICustomerService _customerService;
    private readonly ICustomerRepository _customerRepository;

    public CustomerTests()
    {
        Guid addressId = Guid.NewGuid();
        _customer = new Customer()
        {
            Id = "1",
            FullName = "Test Customer",
            Address = new Address()
            {
                Id = addressId,
                AddressLine = "",
                Number = 1200,
                Complement = "",
                Neighborhood = "Downtown",
                ZipCode = "11325-852",
                City = "São Paulo",
                State = "SP"
            },
            AddressId = addressId,
            Telephone = "(11) 98632-8541",
            Email = "dotnet@test.com"
        };

        _customerRepository = Substitute.For<ICustomerRepository>();
        _customerService = new CustomerService(_customerRepository);
    }

    [Fact]
    public async Task CreateAsync_Should_Return_Valid_Customer()
    {
        _customerRepository.CreateAsync(Arg.Any<Customer>()).Returns(Task.FromResult(_customer));
        Customer newCustomer = new Customer()
        {
            Email = _customer.Email,
            Telephone = _customer.Telephone
        };

        var customer = await _customerService.CreateAsync(newCustomer);

        Assert.NotNull(customer.Address);
    }

    [Fact]
    public async Task GetByIdAsync_Should_Return_Valid_Customer()
    {
        _customerRepository.GetByIdAsync(Arg.Any<string>()).Returns(Task.FromResult(_customer));

        var customer = await _customerService.GetByIdAsync("ID");

        Assert.NotNull(customer);
    }

    [Fact]
    public async Task GetAllCustomers_Should_Return_Valid_List_Customers()
    {
        IList<Customer> customersList = new List<Customer>() { _customer };
        _customerRepository.GetAllAsync().Returns(Task.FromResult(customersList));

        var response = await _customerService.GetAllCustomers();

        Assert.NotEmpty(response);
    }

    [Theory]
    [InlineData("xp-inc@xp.com", true)]
    [InlineData("xp-incxp.com", false)]
    [InlineData("xp-inc@xpcom", false)]
    public async Task ValidateCustomer_Email(string email, bool valid)
    {
        Customer customer = new Customer()
        {
            Telephone = "(11) 98632-8541",
            Email = email
        };

        Exception exception = await Record.ExceptionAsync(async () => await _customerService.CreateAsync(customer));
        bool emailIsValid = exception == null;

        Assert.Equal(valid, emailIsValid);
    }

    [Theory]
    [InlineData("(11)-98765-4321", true)]
    [InlineData("11 987654321", true)]
    [InlineData("(22) 1234-5678", true)]
    [InlineData("44 5678-1234", true)]
    [InlineData("(55)999998888", true)]
    [InlineData("(99)87654321", true)]
    [InlineData("(33) 1234567890", false)]
    [InlineData("123456789", false)]
    [InlineData("(66) 1234567", false)]
    [InlineData("(1) 12345678", false)]
    [InlineData("()", false)]
    [InlineData("-", false)]
    public async Task ValidateCustomer_Telephone(string telephone, bool valid)
    {
        Customer customer = new Customer()
        {
            Telephone = telephone,
            Email = "valid@email.com"
        };

        Exception exception = await Record.ExceptionAsync(async () => await _customerService.CreateAsync(customer));
        bool telephoneIsValid = exception == null;

        Assert.Equal(valid, telephoneIsValid);
    }
}