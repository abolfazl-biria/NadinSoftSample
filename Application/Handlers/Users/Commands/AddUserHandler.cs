using Application.Helper;
using Application.Models.Commands.Users;
using Common.Configurations;
using Common.Dtos;
using Common.Extensions;
using Domain.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Handlers.Users.Commands;

public class AddUserHandler : IRequestHandler<AddUserCommand, ResultDto<string>>
{
    private readonly UserManager<MyUser> _userManager;

    public AddUserHandler(UserManager<MyUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ResultDto<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.Create();

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            var msg = result.Errors.Aggregate("", (current, error) => current + error.Description + Environment.NewLine);

            return new ResultDto<string>
            {
                IsSuccess = false,
                Message = msg,
                Data = ""
            };
        }

        var roleResult = await _userManager.AddToRoleAsync(user, UserRoles.Admin);

        if (roleResult.Succeeded)
        {
            var authClaims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.UserName!),
                new(ClaimTypes.Role, UserRoles.Admin),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = ClaimsPrincipalExtension.GetToken(authClaims);

            return new ResultDto<string>
            {
                IsSuccess = true,
                Message = "با موفقیت انجام شد",
                Data = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        var msg1 = roleResult.Errors.Aggregate("", (current, error) => current + error.Description + Environment.NewLine);

        return new ResultDto<string>
        {
            IsSuccess = false,
            Message = msg1,
            Data = ""
        };
    }
}