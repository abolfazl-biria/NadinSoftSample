using Common.Dtos;
using MediatR;

namespace Application.Models.Commands.Products;

public class AddProductCommand : RequestBaseDto, IRequest<ResultDto>
{
    public AddProductCommand(UserInfoDto userInfo) => UserInfo = userInfo;


    public bool IsAvailable { get; set; }

    public required string Name { get; set; }
    public required string ManufactureEmail { get; set; }
    public required string ManufacturePhone { get; set; }
    public DateTime ProduceDate { get; set; }
}