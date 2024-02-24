using FinancialBot.Application.Interfaces;
using FinancialBot.Domain;
using MediatR;

namespace FinancialBot.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IAppDbContext dbContext) : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new AppUser
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
            ChatId = request.ChatId,
            Username = request.Username,
            FirstName = request.FirstName,
            LastName = request.LastName,
        };

        await dbContext.AppUsers.AddAsync(user, cancellationToken);
        return user.Id;
    }
}