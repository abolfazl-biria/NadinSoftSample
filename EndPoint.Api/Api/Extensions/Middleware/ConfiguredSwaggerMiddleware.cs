namespace EndPoint.Api.Api.Extensions.Middleware;

public static class ConfiguredSwaggerMiddleware
{
    public static void UseConfiguredSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}