using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Contexts;

public class ECommerceApiDbContext : DbContext
{
    public ECommerceApiDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        // ChangeTracker: Entityler uzerinden yapilan degisikliklerin ya da yeni eklenen verinin yakalanmasini saglayan
        // propertydir. Update operasyonlarindaTrack edilen verileri yakalayip elde etmemizi saglar.

        var data = ChangeTracker.Entries<BaseEntity>();
        foreach (var item in data)
        {
            _ = item.State switch
            {
                EntityState.Modified => item.Entity.UpdatedDate = DateTime.UtcNow,
                EntityState.Added => item.Entity.CreatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}