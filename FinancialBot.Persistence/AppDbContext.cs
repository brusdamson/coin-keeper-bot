using FinancialBot.Application.Interfaces;
using FinancialBot.Domain;
using FinancialBot.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FinancialBot.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Purchase> Purchases { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
    
    public DbSet<AppUser> AppUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseProductConfiguration());
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}