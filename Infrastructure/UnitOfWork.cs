using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class UnitOfWork(MyDbContext context)
{
    public IRepository<User> UserRepository { get; set; } = new UserRepository(context);
    public IRepository<Code> CodeRepository { get; set; } = new CodeRepository(context);

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
        
}