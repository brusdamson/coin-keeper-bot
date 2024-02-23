using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinancialBot.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialBot.Application.Products.Queries.GetProductList;

public class GetPurchaseProductsListQueryHandler(IAppDbContext dbContext, IMapper mapper)
    : IRequestHandler<GetPurchaseProductsListQuery, PurchaseProductsListVm>
{
    public async Task<PurchaseProductsListVm> Handle(GetPurchaseProductsListQuery request,
        CancellationToken cancellationToken)
    {
        var products = await dbContext.Purchases
            .Where(purchase => purchase.Id == request.PurchaseId).Select(p => p.Products)
            .ProjectTo<PurchaseProductsDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new PurchaseProductsListVm
        {
            Products = products,
        };
    }
}