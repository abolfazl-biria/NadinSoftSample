using Infrastructure.MappingProfile;

namespace EndPoint.Api.Api.Extensions.DependencyInjection;

public static class AutoMapperInjection
{
    public static IServiceCollection AddConfiguredAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ProfileMapping));

        return services;
    }
}