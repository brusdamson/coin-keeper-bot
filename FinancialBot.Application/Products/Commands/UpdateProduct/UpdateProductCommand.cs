using MediatR;

namespace FinancialBot.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }
}