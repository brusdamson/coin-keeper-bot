using FinancialBot.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialBot.Persistence.EntityTypeConfigurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(user => user.Id);
        builder.Property(user => user.ChatId).IsRequired();
        builder.Property(user => user.Username).IsRequired();
    }
}