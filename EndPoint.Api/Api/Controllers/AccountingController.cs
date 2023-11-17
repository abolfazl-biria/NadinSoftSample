using Application.Models.Commands.Users;
using EndPoint.Api.Api.Extensions;
using EndPoint.Api.Api.RequestModels.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Api.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AccountingController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost, Route("Login")]
    public async Task<IActionResult> Login(LoginUserRequestDto request)
    {
        var result = await _mediator.Send(new LoginUserCommand
        {
            Password = request.Password,
            UserName = request.UserName,
        });

        return this.ReturnResponse(result);
    }

    [HttpPost, Route("SignUp")]
    public async Task<IActionResult> SignUp(AddUserRequestDto request)
    {
        var result = await _mediator.Send(new AddUserCommand
        {
            Email = request.Email,
            Password = request.Password,
            PhoneNumber = request.PhoneNumber,
            UserName = request.UserName,
        });

        return this.ReturnResponse(result);
    }
}