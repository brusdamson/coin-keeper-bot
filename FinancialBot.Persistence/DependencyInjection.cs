using FinancialBot.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialBot.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>()!);

        using (var serviceScope = services.BuildServiceProvider().CreateScope())
        {
            try
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                DbInitializer.Initialize(dbContext);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        return services;
    }
}