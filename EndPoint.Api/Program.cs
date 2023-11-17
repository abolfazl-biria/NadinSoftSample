using Domain.Entities.Users;
using EndPoint.Api.Api.Extensions.DependencyInjection;
using EndPoint.Api.Api.Extensions.Middleware;
using Microsoft.AspNetCore.Identity;
using Persistence.SeedData;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;
var environment = builder.Environment;

// Add services to the container.

services
    .AddServices()
    .AddConfiguredDatabase(configuration)
    .AddConfiguredIdentity(configuration)
    .AddConfiguredSwagger()
    .AddConfiguredMediatR()
    .AddConfiguredValidation();

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseConfiguredSwagger();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseConfiguredExceptionHandler(environment);

//seed
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<MyRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<MyUser>>();

    SeedData.SeedUsers(userManager, roleManager);
}

app.MapControllers();

app.Run();