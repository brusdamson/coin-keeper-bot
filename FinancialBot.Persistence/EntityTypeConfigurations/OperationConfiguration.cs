using FinancialBot.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialBot.Persistence.EntityTypeConfigurations;

public class OperationConfiguration : IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder.HasKey(op => op.Id);

        builder.HasOne(op => op.Category)
            .WithMany(ctg => ctg.Operations)
            .HasForeignKey(op => op.CategoryId);

        builder.HasOne(op => op.User)
            .WithMany(user => user.Operations)
            .HasForeignKey(op => op.UserId);

        builder.HasOne(op => op.Purchase)
            .WithMany(purchase => purchase.Operations)
            .HasForeignKey(op => op.PurchaseId);
    }
}