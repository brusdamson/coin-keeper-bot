using System.Reflection;
using FinancialBot.Application.Common.Mappings;
using FinancialBot.Application.Common.Services;
using FinancialBot.Application.Common.Services.Interfaces;
using FinancialBot.Application.Common.Telegram;
using FinancialBot.Application.Common.Telegram.Extensions;
using FinancialBot.Application.Common.Telegram.Services;
using FinancialBot.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace FinancialBot.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        SetupConfiguration(services, configuration);
        ConfigureTelegramBot(services);
        ConfigureMapUtilities(services);
        ConfigureMediatr(services);
        ConfigureUtilityServices(services);

        return services;
    }

    private static void SetupConfiguration(IServiceCollection services, IConfiguration configuration)
    {
        var botConfigurationSection = configuration.GetSection(BotConfiguration.Configuration);
        services.Configure<BotConfiguration>(botConfigurationSection);
    }

    private static void ConfigureTelegramBot(IServiceCollection services)
    {
        services.AddHttpClient("telegram_bot_client")
            .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
            {
                var botConfig = sp.GetConfiguration<BotConfiguration>();
                TelegramBotClientOptions options = new(botConfig.BotToken);
                return new TelegramBotClient(options, httpClient);
            });

        services.AddScoped<UpdateHandlers>();
        services.AddHostedService<ConfigureWebhook>();
    }

    private static void ConfigureMapUtilities(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IAppDbContext).Assembly));
        });
    }

    private static void ConfigureMediatr(IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
    }

    private static void ConfigureUtilityServices(IServiceCollection services)
    {
        services.AddSingleton<IQrReader, QrReaderService>();
    }
}