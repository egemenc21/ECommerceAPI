using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ECommerceAPI.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceApiDbContext>
{
    public ECommerceApiDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ECommerceApiDbContext> dbContextOptionsBuilder = new();

        dbContextOptionsBuilder.UseNpgsql(
            "User ID=postgres;Password=415987;Host=localhost;Port=5432;Database=e_commerce_db;");
        return new(dbContextOptionsBuilder.Options);
    }
}