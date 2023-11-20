using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ECom.Domain.Entities;
using ECom.Domain.Entities.Identity;
using ECom.Domain.Entities.Common;
using ECom.Persistence.Configurations;

namespace ECom.Persistence;


public class EComDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    public EComDbContext() { }
    public EComDbContext(DbContextOptions<EComDbContext> options) : base(options) 
    {
    
    }

    #region Entities

    public DbSet<BaseFile> BaseFiles { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Domain.Entities.File> Files { get; set; }
    public DbSet<InvoiceFile> InvoiceFiles { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImageFile> ProductImageFiles { get; set; }
    public DbSet<Product_Order> Products_Orders { get; set; }
    public DbSet<Size> Sizes { get; set; }

    #endregion

    #region Customized SaveChangesAsync

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker.Entries<BaseEntity>();

        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    #endregion

    #region OnModelCreating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product_Order>().HasKey(x => new { x.ProductId, x.OrderId });
        modelBuilder.Entity<Product_Order>().HasOne(m => m.Order).WithMany(am => am.Products_Orders).HasForeignKey(m => m.OrderId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Product_Order>().HasOne(m => m.Product).WithMany(am => am.Products_Orders).HasForeignKey(m => m.ProductId).OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Basket>().HasOne(b => b.Order).WithOne(o => o.Basket).HasForeignKey<Order>(b => b.Id);

        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new BrandConfiguration());
        modelBuilder.ApplyConfiguration(new ColorConfiguration());
        modelBuilder.ApplyConfiguration(new SizeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new BasketConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OfferConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceFileConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    #endregion
}
