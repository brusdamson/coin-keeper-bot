using FinancialBot.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialBot.Persistence.EntityTypeConfigurations;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.PurchaseDate).IsRequired();
        builder.Property(p => p.TotalCost).IsRequired();

        builder.HasMany(p => p.PurchaseProducts)
            .WithOne(pp => pp.Purchase)
            .HasForeignKey(pp => pp.PurchaseId);
    }
}