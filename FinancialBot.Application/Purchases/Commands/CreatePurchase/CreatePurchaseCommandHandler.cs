using FinancialBot.Application.Interfaces;
using FinancialBot.Domain;
using MediatR;

namespace FinancialBot.Application.Purchases.Commands.CreatePurchase;

public class CreatePurchaseCommandHandler(IAppDbContext dbContext) : IRequestHandler<CreatePurchaseCommand, Guid>
{
    public async Task<Guid> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    {
        var purchase = new Purchase
        {
            Id = Guid.NewGuid(),
            PurchaseDate = request.PurchaseDate,
        };

        var purchaseProducts = request.Products.Select(p => new PurchaseProduct
        {
            Id = Guid.NewGuid(),
            ProductId = p.ProductId,
            PurchaseId = purchase.Id,
        }).ToList();

        await dbContext.Purchases.AddAsync(purchase, cancellationToken);
        await dbContext.PurchaseProducts.AddRangeAsync(purchaseProducts, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return purchase.Id;
    }
}