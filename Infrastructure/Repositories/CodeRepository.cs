using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CodeRepository(MyDbContext dbContext) :BaseRepository<Code>(dbContext)
{
    public override async Task AddNewEntityAsync(Code entity)
    {
        var oldRecord = await base.GetEntityFirstOrDefaultAsync(x=>x.UserPhoneOrEmail == entity.UserPhoneOrEmail);
        if (oldRecord != null) await base.DeleteEntityAsync(oldRecord);
        await base.AddNewEntityAsync(entity);
    }
}