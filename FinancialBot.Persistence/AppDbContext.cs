using FinancialBot.Application.Interfaces;
using FinancialBot.Domain;
using FinancialBot.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FinancialBot.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
{
    public DbSet<Purchase> Purchases { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
    
    public DbSet<AppUser> AppUsers { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Operation> Operations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseProductConfiguration());
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        modelBuilder.ApplyConfiguration(new OperationConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}