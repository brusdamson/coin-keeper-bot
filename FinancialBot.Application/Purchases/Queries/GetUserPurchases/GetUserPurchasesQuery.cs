using MediatR;

namespace FinancialBot.Application.Purchases.Queries.GetUserPurchases;

public class GetUserPurchasesQuery : IRequest<UserPurchasesListVm>
{
    public Guid UserId { get; set; }
}