using Application.Behaviors;
using Application.Models.Commands.Users;
using MediatR;

namespace EndPoint.Api.Api.Extensions.DependencyInjection;

public static class MediatRInjection
{
    public static IServiceCollection AddConfiguredMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {

            cfg.RegisterServicesFromAssemblies(typeof(AddUserCommand).Assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        return services;
    }
}