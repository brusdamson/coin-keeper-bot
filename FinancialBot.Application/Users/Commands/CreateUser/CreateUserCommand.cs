using MediatR;

namespace FinancialBot.Application.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<Guid>
{
    public long ChatId { get; set; }

    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}