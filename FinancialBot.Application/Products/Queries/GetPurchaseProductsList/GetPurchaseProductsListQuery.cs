using MediatR;

namespace FinancialBot.Application.Products.Queries.GetProductList;

public class GetPurchaseProductsListQuery : IRequest<PurchaseProductsListVm>
{
    public Guid PurchaseId { get; set; }
}