using FinancialBot.Application;
using FinancialBot.Application.Common.Telegram;
using FinancialBot.Application.Common.Telegram.Extensions;
using FinancialBot.Core.Controllers;
using FinancialBot.Persistence;

var builder = WebApplication.CreateBuilder(args);
var botConfigurationSection = builder.Configuration.GetSection(BotConfiguration.Configuration);
var botConfiguration = botConfigurationSection.Get<BotConfiguration>();

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapBotWebhookRoute<TelegramBotController>(botConfiguration!.Route);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();