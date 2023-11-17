using Application.Models.Commands.Users;
using Common.Dtos;
using Common.Extensions;
using Domain.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Handlers.Users.Commands;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, ResultDto<string>>
{
    private readonly SignInManager<MyUser> _signInManager;
    private readonly UserManager<MyUser> _userManager;
    public LoginUserHandler(
        SignInManager<MyUser> signInManager,
        UserManager<MyUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<ResultDto<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, true);

        if (result.Succeeded)
        {
            var user = _userManager.FindByNameAsync(request.UserName).Result;

            var userRoles = await _userManager.GetRolesAsync(user!);

            var userRole = userRoles.FirstOrDefault() ?? "";

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user!.Id.ToString()),
                new(ClaimTypes.Name, user.UserName!),
                new(ClaimTypes.Role, userRole),
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

        if (result.IsLockedOut)
        {
            return new ResultDto<string>
            {
                Message = "اکانت شما به دلیل پنج بار ورود ناموفق به مدت پنج دقیقه قفل شده است",
                IsSuccess = false,
                Data = ""
            };
        }

        return new ResultDto<string>
        {
            Message = result.IsNotAllowed ? "اکانت شما توسط مدیر قفل شده است" : "رمزعبور یا نام کاربری اشتباه است",
            IsSuccess = false,
            Data = ""
        };
    }
}