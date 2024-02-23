using Microsoft.Extensions.Configuration;
using Telegram.Bot;

namespace FinancialBot.Persistence.Telegram;

public class TelegramBotFactory(IConfiguration configuration)
{
    private TelegramBotClient? _client;

    public async Task<TelegramBotClient?> GetConfiguredBot()
    {
        if (_client != null) return _client;

        _client = new TelegramBotClient(configuration["Token"] ?? string.Empty);

        string webHook = $"{configuration["WebHook"]?.TrimEnd('/')}/api/message/update";
        await _client.SetWebhookAsync(webHook);

        return _client;
    }
}