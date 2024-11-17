using System.Data.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set;}
    public DbSet<Code> Codes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}