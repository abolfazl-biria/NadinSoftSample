using Common.Dtos;
using MediatR;

namespace Application.Models.Commands.Users;

public class LoginUserCommand : IRequest<ResultDto<string>>
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}