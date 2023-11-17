using Application.Validators.Users;
using FluentValidation;

namespace EndPoint.Api.Api.Extensions.DependencyInjection;

public static class ValidationInjection
{
    public static IServiceCollection AddConfiguredValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(AddUserCommandValidator).Assembly);

        return services;
    }
}