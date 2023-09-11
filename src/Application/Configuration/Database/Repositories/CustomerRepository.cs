using Microsoft.EntityFrameworkCore;
using Xp.Api.Application.Domain;

namespace Xp.Api.Application.Configuration.Database.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseContext _context;
    private readonly DbSet<Customer> _entity;

    public CustomerRepository(DatabaseContext context)
    {
        _context = context;
        _entity = _context.Set<Customer>();
    }

    public async Task<Customer> GetByIdAsync(string id)
    {
        return await _entity.FindAsync(id).AsTask();
    }

    public async Task<IList<Customer>> GetAllAsync()
    {
        return await _entity.ToListAsync();
    }

    public async Task<Customer> CreateAsync(Customer model)
    {
        await _entity.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<Customer> UpdateAsync(Customer model)
    {
        _context.ChangeTracker.Clear();
        _entity.Update(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task DeleteAsync(Customer model)
    {
        _entity.Remove(model);
        await _context.SaveChangesAsync();
    }
}