using FinancialBot.Application.Interfaces;
using FinancialBot.Domain;
using MediatR;

namespace FinancialBot.Application.Products.Commands.CreatePurchase;

public class CreatePurchaseCommandHandler(IAppDbContext dbContext) : IRequestHandler<CreatePurchaseCommand, Guid>
{
    public async Task<Guid> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    {
        var purchase = new Purchase
        {
            Id = Guid.NewGuid(),
            PurchaseDate = request.PurchaseDate,
            PurchaseProducts = request.Products.Select(p => new PurchaseProduct
            {
                Id = Guid.NewGuid(),
                ProductId = p.ProductId,
            }).ToList(),
        };

        await dbContext.Purchases.AddAsync(purchase, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return purchase.Id;
    }
}