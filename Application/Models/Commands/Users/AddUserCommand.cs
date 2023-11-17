using Common.Dtos;
using MediatR;

namespace Application.Models.Commands.Users;

public class AddUserCommand : IRequest<ResultDto<string>>
{
    public required string UserName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}