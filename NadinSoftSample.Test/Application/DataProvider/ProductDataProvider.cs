using Application.Models.Commands.Products;
using Common.Dtos;

namespace NadinSoftSample.Test.Application.DataProvider;

public static class ProductDataProvider
{
    public static List<object[]> Add()
    {
        return new List<object[]>()
        {
            new object[]
            {
                new AddProductCommand(new UserInfoDto {IsAdmin = true, UserId = 1})
                {
                    ManufactureEmail = "aaa@gmail.com",
                    ManufacturePhone = "12345678901",
                    Name = "aa",
                    ProduceDate = new DateTime(2022, 8, 1, 1, 1, 1),
                    IsAvailable = true,
                }
            }
        };
    }

    public static List<object[]> Update()
    {
        return new List<object[]>()
        {
            new object[]
            {
                new UpdateProductCommand(new UserInfoDto {IsAdmin = true, UserId = 1})
                {
                    Id = 1,
                    ManufactureEmail = "aaa@gmail.com",
                    ManufacturePhone = "12345678901",
                    Name = "aa",
                    ProduceDate = new DateTime(2022, 8, 1, 1, 1, 1),
                    IsAvailable = true,
                }
            }
        };
    }

    public static List<object[]> Delete()
    {
        return new List<object[]>()
        {
            new object[]
            {
                new DeleteProductCommand(new UserInfoDto {IsAdmin = true, UserId = 1})
                {
                    Id = 1,
                }
            }
        };
    }
}