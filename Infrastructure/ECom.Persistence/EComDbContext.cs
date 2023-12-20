using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ECom.Domain.Entities;
using ECom.Domain.Entities.Identity;
using ECom.Domain.Entities.Common;

namespace ECom.Persistence;


public class EComDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public EComDbContext(DbContextOptions<EComDbContext> options) : base(options) 
    {
    
    }

    #region Entities
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<ECom.Domain.Entities.File> Files { get; set; }
    public DbSet<ProductImageFile> ProductImageFiles { get; set; }
    public DbSet<InvoiceFile> InvoiceFiles { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<CompletedOrder> CompletedOrders { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Endpoint> Endpoints { get; set; }

    #endregion

    #region Customized SaveChangesAsync

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker.Entries<BaseEntity>();

        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    #endregion

    #region OnModelCreating

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<Order>()
                .HasKey(b => b.Id);

        builder.Entity<Order>()
            .HasIndex(o => o.OrderCode)
            .IsUnique();

        builder.Entity<Basket>()
            .HasOne(b => b.Order)
            .WithOne(o => o.Basket)
            .HasForeignKey<Order>(b => b.Id);

        builder.Entity<Order>()
            .HasOne(o => o.CompletedOrder)
            .WithOne(c => c.Order)
            .HasForeignKey<CompletedOrder>(c => c.OrderId);

        base.OnModelCreating(builder);
    }

    #endregion
}
