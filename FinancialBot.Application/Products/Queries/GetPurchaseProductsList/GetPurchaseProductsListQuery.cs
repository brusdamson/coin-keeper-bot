using MediatR;

namespace FinancialBot.Application.Products.Queries.GetPurchaseProductsList;

public class GetPurchaseProductsListQuery : IRequest<PurchaseProductsListVm>
{
    public Guid PurchaseId { get; set; }
}