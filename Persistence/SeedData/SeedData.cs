using Common.Configurations;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;


namespace Persistence.SeedData;

public static class SeedData
{
    public static void SeedUsers(UserManager<MyUser> userManager, RoleManager<MyRole> roleManager)
    {
        if (!roleManager.RoleExistsAsync(UserRoles.Admin).Result)
        {
            _ = roleManager.CreateAsync(new MyRole
            { Name = UserRoles.Admin, NormalizedName = UserRoles.Admin.ToUpper() }).Result;
        }

        if (userManager.FindByNameAsync("abolfazl").Result != null) return;

        MyUser user = new()
        {
            UserName = "abolfazl",
            NormalizedUserName = "abolfazl".ToUpper(),
        };

        var result = userManager.CreateAsync(user, "a123456789").Result;

        if (result.Succeeded)
        {
            _ = userManager.AddToRoleAsync(user, UserRoles.Admin).Result;
        }
    }
}