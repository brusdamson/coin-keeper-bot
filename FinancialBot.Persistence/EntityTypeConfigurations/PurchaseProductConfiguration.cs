using FinancialBot.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialBot.Persistence.EntityTypeConfigurations;

public class PurchaseProductConfiguration : IEntityTypeConfiguration<PurchaseProduct>
{
    public void Configure(EntityTypeBuilder<PurchaseProduct> builder)
    {
        builder.HasOne(pp => pp.Purchase)
            .WithMany(p => p.PurchaseProducts)
            .HasForeignKey(pp => pp.PurchaseId);

        builder.HasOne(pp => pp.Product)
            .WithMany(p => p.PurchaseProducts)
            .HasForeignKey(pp => pp.ProductId);
    }
}