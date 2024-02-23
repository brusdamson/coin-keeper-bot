using FinancialBot.Application.Products.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialBot.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IMediator _mediator;

    public TestController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateProductCommand>> Create(CreateProductCommand product)
    {
        await _mediator.Send(product);
        return Ok();
    }
}