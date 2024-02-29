using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace FinancialBot.Application.Common.Telegram.Services;

public class ConfigureWebhook(IServiceProvider serviceProvider, IOptions<BotConfiguration> botOptions) : IHostedService
{
    private readonly BotConfiguration _botConfig = botOptions.Value;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

        string webhookAddress = $"{_botConfig.HostAddress}{_botConfig.Route}";
        await botClient.SetWebhookAsync(
            webhookAddress,
            allowedUpdates: Array.Empty<UpdateType>(),
            secretToken: _botConfig.SecretToken,
            cancellationToken: cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

        await botClient.DeleteWebhookAsync(cancellationToken: cancellationToken);
    }
}