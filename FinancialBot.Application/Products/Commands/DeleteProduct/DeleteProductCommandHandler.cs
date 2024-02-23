using FinancialBot.Application.Common.Exceptions;
using FinancialBot.Application.Interfaces;
using FinancialBot.Domain;
using MediatR;

namespace FinancialBot.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler(IAppDbContext dbContext) : IRequestHandler<DeleteProductCommand>
{
    private readonly IAppDbContext _dbContext = dbContext;

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products.FindAsync(new object[] { request.Id }, cancellationToken);

        if (product == null) throw new EntityNotFoundException(nameof(Product), request.Id);

        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}