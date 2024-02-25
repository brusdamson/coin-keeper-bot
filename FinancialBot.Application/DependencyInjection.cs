using System.Reflection;
using FinancialBot.Application.Telegram.Interfaces;
using FinancialBot.Application.Telegram.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialBot.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        
        services.AddSingleton<IQrReader, QrReaderService>();
        
        return services;
    }
}