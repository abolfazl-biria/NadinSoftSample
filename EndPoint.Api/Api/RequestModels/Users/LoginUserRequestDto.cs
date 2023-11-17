namespace EndPoint.Api.Api.RequestModels.Users;

public class LoginUserRequestDto
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}