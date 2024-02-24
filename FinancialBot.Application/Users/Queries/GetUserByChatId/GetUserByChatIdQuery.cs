using MediatR;

namespace FinancialBot.Application.Users.Queries.GetUserByChatId;

public class GetUserByChatIdQuery : IRequest<AppUserDto>
{
    public long ChatId { get; set; }
}