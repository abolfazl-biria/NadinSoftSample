using Application.Models.Commands.Products;
using Domain.Entities.Products;

namespace Application.Helper;

public static class ProductHelper
{
    public static Product Create(this AddProductCommand command) =>
        new()
        {
            ManufactureEmail = command.ManufactureEmail,
            ManufacturePhone = command.ManufacturePhone,
            Name = command.Name,
            ProduceDate = command.ProduceDate,
            CreatorId = command.UserInfo.UserId,
            IsAvailable = command.IsAvailable,

            InsertTime = DateTime.Now,
            IsRemoved = false,
        };

    public static Product Update(this Product product, UpdateProductCommand command)
    {
        product.ManufactureEmail = command.ManufactureEmail;
        product.ManufacturePhone = command.ManufacturePhone;
        product.Name = command.Name;
        product.ProduceDate = command.ProduceDate;
        product.CreatorId = command.UserInfo.UserId;
        product.IsAvailable = command.IsAvailable;

        product.UpdaterId = command.UserInfo.UserId;
        product.UpdateTime = DateTime.Now;

        return product;
    }
}