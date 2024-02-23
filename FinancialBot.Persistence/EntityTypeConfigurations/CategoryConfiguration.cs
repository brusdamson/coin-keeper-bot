using FinancialBot.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialBot.Persistence.EntityTypeConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(ctg => ctg.Id);
        builder.Property(ctg => ctg.Name).IsRequired();
        
        builder.HasMany(ctg => ctg.Operations)
            .WithOne(op => op.Category)
            .HasForeignKey(op => op.CategoryId);
    }
}