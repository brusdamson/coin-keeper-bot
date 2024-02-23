using FinancialBot.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinancialBot.Application.Interfaces;

public interface IAppDbContext
{
    DbSet<Product> Products { get; set; }

    DbSet<Purchase> Purchases { get; set; }

    DbSet<PurchaseProduct> PurchaseProducts { get; set; }
    
    DbSet<AppUser> AppUsers { get; set; }
    
    DbSet<Category> Categories { get; set; }
    
    DbSet<Operation> Operations { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellation);
}