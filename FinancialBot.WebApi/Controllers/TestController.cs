using FinancialBot.Application.Products.Commands;
using FinancialBot.Application.Telegram.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialBot.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IQrReader _qrReader;

    public TestController(IMediator mediator, IQrReader qrReader)
    {
        _mediator = mediator;
        _qrReader = qrReader;
    }

    [HttpPost]
    public async Task<ActionResult<CreateProductCommand>> Create(CreateProductCommand product)
    {
        await _mediator.Send(product);
        return Ok();
    }
}