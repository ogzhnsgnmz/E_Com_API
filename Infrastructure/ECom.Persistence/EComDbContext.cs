using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ECom.Domain.Entities;
using ECom.Domain.Entities.Identity;
using ECom.Domain.Entities.Common;
using System.Drawing;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Reflection.Emit;
using Persistence.Configurations;

namespace ECom.Persistence;


public class EComDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    private IDbContextTransaction _currentTransaction;
    public EComDbContext(DbContextOptions<EComDbContext> options) : base(options)
    {

    }

    #region Entities
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Domain.Entities.File> Files { get; set; }
    public DbSet<ProductImageFile> ProductImageFiles { get; set; }
    public DbSet<InvoiceFile> InvoiceFiles { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<CompletedOrder> CompletedOrders { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Endpoint> Endpoints { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Domain.Entities.Size> Sizes { get; set; }
    public DbSet<ProductAttribute> ProductAttributes { get; set; }
    public DbSet<Domain.Entities.Attribute> Attributes { get; set; }
    public DbSet<Address> Addresses { get; set; }

    #endregion

    #region UnitOfWork
    public bool HasActiveTransaction => _currentTransaction != null;

    public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

    public async Task BeginTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            return;
        }

        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await SaveChangesAsync();

            _currentTransaction?.Commit();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    public void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
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

        //builder.ApplyConfiguration(new ProductConfiguration());

        base.OnModelCreating(builder);
    }

    #endregion
}