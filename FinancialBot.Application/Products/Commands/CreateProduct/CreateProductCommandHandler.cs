using FinancialBot.Application.Interfaces;
using FinancialBot.Domain;
using MediatR;

namespace FinancialBot.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(IAppDbContext dbContext) : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.GoodName,
            Price = request.GoodPrice,
        };

        await dbContext.Products.AddAsync(product, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}