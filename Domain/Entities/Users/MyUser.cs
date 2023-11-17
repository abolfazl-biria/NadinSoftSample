using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Users;

public class MyUser : IdentityUser<int>, IEntity
{

}