﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FinancialBot.Application.Common.Telegram.Extensions;

public static class WebHookExtensions
{
    public static T GetConfiguration<T>(this IServiceProvider serviceProvider)
        where T : class
    {
        var o = serviceProvider.GetService<IOptions<T>>();
        if (o is null)
            throw new ArgumentNullException(nameof(T));

        return o.Value;
    }

    public static ControllerActionEndpointConventionBuilder MapBotWebhookRoute<T>(
        this IEndpointRouteBuilder endpoints,
        string route)
    {
        string controllerName = typeof(T).Name.Replace("Controller", "", StringComparison.Ordinal);
        string actionName = typeof(T).GetMethods()[0].Name;

        return endpoints.MapControllerRoute(
            "bot_webhook",
            route,
            new { controller = controllerName, action = actionName });
    }
}