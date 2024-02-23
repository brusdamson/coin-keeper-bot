using FinancialBot.Persistence;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FinancialBot.Core.Controllers;

[ApiController]
[Route("api/message")]
public class TelegramBotController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly TelegramBotClient _telegramBotClient;

    public TelegramBotController(AppDbContext dbContext, TelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
        _dbContext = dbContext;
    }

    [HttpPost("update")]
    public IActionResult Update(Update update)
    {
        return Ok();
    }
}