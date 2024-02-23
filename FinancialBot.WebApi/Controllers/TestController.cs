using FinancialBot.Application.Products.Commands;
using FinancialBot.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialBot.Core.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    private readonly IMediator _mediator;

    public TestController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public IActionResult Update(CreateProductCommand product)
    {
        _mediator.Send(product);
        return Ok();
    }
}