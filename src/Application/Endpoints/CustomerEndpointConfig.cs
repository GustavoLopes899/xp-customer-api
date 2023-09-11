using Swashbuckle.AspNetCore.Annotations;
using Xp.Api.Application.Domain;
using Xp.Api.Application.Handlers;
using Xp.Api.Application.Services;

namespace Xp.Api.Application.Endpoints;

public class CustomerEndpointConfig
{
    public static void AddEndpoints(WebApplication app)
    {
        app.MapPost("/customer", async (Customer customer, ICustomerService customerService) =>
        {
            try
            {
                Customer newCostumer = await customerService.CreateAsync(customer);
                return Results.Ok(newCostumer);
            }
            catch (Exception exception)
            {
                string message = ExceptionMessageHandler.ExtractExceptionMessage(exception);
                return Results.BadRequest(message);
            }
        })
            .WithMetadata(new SwaggerOperationAttribute("Add a new customer", "Add a new customer to the database"),
                new SwaggerResponseAttribute(StatusCodes.Status200OK, "Customer added successfully"),
                new SwaggerResponseAttribute(StatusCodes.Status400BadRequest, "Bad Request"));

        app.MapGet("/customers", async (ICustomerService customerService) =>
        {
            try
            {
                IList<Customer> customers = await customerService.GetAllCustomers();
                return Results.Ok(customers);
            }
            catch (Exception exception)
            {
                string message = ExceptionMessageHandler.ExtractExceptionMessage(exception);
                return Results.BadRequest(message);
            }
        })
            .WithMetadata(new SwaggerOperationAttribute("List all customers", "List all customers on database"),
                new SwaggerResponseAttribute(StatusCodes.Status200OK, "Sucess"),
                new SwaggerResponseAttribute(StatusCodes.Status400BadRequest, "Bad Request"));

        app.MapGet("/customer", async (string id, ICustomerService customerService) =>
        {
            try
            {
                Customer customer = await customerService.GetByIdAsync(id);
                if (customer == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(new { customer.Address, customer.Email });
            }
            catch (Exception exception)
            {
                string message = ExceptionMessageHandler.ExtractExceptionMessage(exception);
                return Results.BadRequest(message);
            }
        })
            .WithMetadata(new SwaggerOperationAttribute("List specific customer by id", "List an specific customer by id"),
                new SwaggerResponseAttribute(StatusCodes.Status200OK, "Sucess"),
                new SwaggerResponseAttribute(StatusCodes.Status400BadRequest, "Bad Request"));
    }
}