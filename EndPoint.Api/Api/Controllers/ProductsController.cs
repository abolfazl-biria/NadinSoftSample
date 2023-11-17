using Application.Models.Commands.Products;
using Application.Models.Queries.Products;
using Common.Configurations;
using Common.Extensions;
using EndPoint.Api.Api.Extensions;
using EndPoint.Api.Api.RequestModels.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Api.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet, Route("get")]
    public async Task<IActionResult> GetAll([FromQuery] GetProductsByFilterRequestDto request)
    {
        var result = await _mediator.Send(new GetProductsByFilterQuery()
        {
            Filter = new ProductFilter(request.Page, request.PageSize, request.Pagination)
            {
                CreatorId = request.CreatorId,
            }
        });

        return this.ReturnResponse(result);
    }

    [HttpGet, Route("get/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery
        {
            Id = id,
        });

        return this.ReturnResponse(result);
    }

    [Authorize(Roles = UserRoles.Admin)]
    [HttpPost, Route("add")]
    public async Task<IActionResult> Add([FromBody] AddProductRequestDto request)
    {
        var result = await _mediator.Send(new AddProductCommand(User.GetUserInfo())
        {
            ManufactureEmail = request.ManufactureEmail,
            ManufacturePhone = request.ManufacturePhone,
            Name = request.Name,
            ProduceDate = request.ProduceDate,
            IsAvailable = request.IsAvailable
        });

        return this.ReturnResponse(result);
    }

    [Authorize(Roles = UserRoles.Admin)]
    [HttpPut, Route("update/{id:int}")]
    public async Task<IActionResult> Add([FromRoute] int id, [FromBody] UpdateProductRequestDto request)
    {
        var result = await _mediator.Send(new UpdateProductCommand(User.GetUserInfo())
        {
            Id = id,
            ManufactureEmail = request.ManufactureEmail,
            ManufacturePhone = request.ManufacturePhone,
            Name = request.Name,
            ProduceDate = request.ProduceDate,
            IsAvailable = request.IsAvailable
        });

        return this.ReturnResponse(result);
    }

    [Authorize(Roles = UserRoles.Admin)]
    [HttpDelete, Route("delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteProductCommand(User.GetUserInfo())
        {
            Id = id,
        });

        return this.ReturnResponse(result);
    }
}