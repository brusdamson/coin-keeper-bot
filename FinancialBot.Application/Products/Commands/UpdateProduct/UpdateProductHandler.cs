using FinancialBot.Application.Common.Exceptions;
using FinancialBot.Application.Interfaces;
using FinancialBot.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialBot.Application.Products.Commands.UpdateProduct;

public class UpdateProductHandler(IAppDbContext dbContext) : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product =
            await dbContext.Products.FirstOrDefaultAsync(product => product.Id == request.Id, cancellationToken);

        if (product == null) throw new EntityNotFoundException(nameof(Product), request.Id);

        product.Name = request.Name;
        product.Price = request.Price;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}