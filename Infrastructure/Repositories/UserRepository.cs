using Domain.Entities;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository(MyDbContext dbContext) :BaseRepository<User>(dbContext)
{
    
}