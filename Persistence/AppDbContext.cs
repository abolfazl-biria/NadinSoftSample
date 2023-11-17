using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Persistence;

public sealed class AppDbContext : IdentityDbContext<MyUser, MyRole, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        if (Database.GetService<IDatabaseCreator>() is not RelationalDatabaseCreator dbCreator) return;

        //Create Database
        if (!dbCreator.CanConnect())
        {
            dbCreator.Create();
        }

        // Create Tables
        if (!dbCreator.HasTables())
        {
            dbCreator.CreateTables();
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Apply Configurations
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(builder);
    }
}