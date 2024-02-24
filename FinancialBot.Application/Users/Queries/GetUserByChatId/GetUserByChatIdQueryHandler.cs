using AutoMapper;
using FinancialBot.Application.Common.Exceptions;
using FinancialBot.Application.Interfaces;
using FinancialBot.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialBot.Application.Users.Queries.GetUserByChatId;

public class GetUserByChatIdQueryHandler(IAppDbContext dbContext, IMapper mapper) : IRequestHandler<GetUserByChatIdQuery, AppUserDto>
{
    public async Task<AppUserDto> Handle(GetUserByChatIdQuery request, CancellationToken cancellationToken)
    {
        var user = await dbContext.AppUsers.FirstOrDefaultAsync(user => user.ChatId == request.ChatId,
            cancellationToken);

        if (user == null)
        {
            throw new EntityNotFoundException(nameof(AppUser), request.ChatId);
        }

        return mapper.Map<AppUserDto>(user);
    }
}