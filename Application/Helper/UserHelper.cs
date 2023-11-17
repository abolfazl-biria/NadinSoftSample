using Application.Models.Commands.Users;
using Domain.Entities.Users;

namespace Application.Helper;

public static class UserHelper
{
    public static MyUser Create(this AddUserCommand command) =>
        new()
        {
            UserName = command.UserName,
            PhoneNumber = command.PhoneNumber,
            PhoneNumberConfirmed = true,
            EmailConfirmed = true,
            Email = command.Email,
        };
}