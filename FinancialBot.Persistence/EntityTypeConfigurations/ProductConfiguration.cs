using FinancialBot.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialBot.Persistence.EntityTypeConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Price).IsRequired();

        builder.HasMany(p => p.PurchaseProducts)
            .WithOne(pp => pp.Product)
            .HasForeignKey(pp => pp.ProductId);
    }
}