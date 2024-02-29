using MediatR;

namespace FinancialBot.Application.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<Guid>
{
    public int GoodPrice { get; set; }

    public required string GoodName { get; set; }
}