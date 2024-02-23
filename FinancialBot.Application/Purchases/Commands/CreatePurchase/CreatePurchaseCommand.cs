using MediatR;

namespace FinancialBot.Application.Products.Commands.CreatePurchase;

public class CreatePurchaseCommand : IRequest<Guid>
{
    public DateTime PurchaseDate { get; set; }

    public List<PurchaseProductDto> Products { get; set; }
}