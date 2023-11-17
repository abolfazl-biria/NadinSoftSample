using Common.Dtos;
using MediatR;

namespace Application.Models.Commands.Products;

public class UpdateProductCommand : RequestBaseDto, IRequest<ResultDto>
{
    public UpdateProductCommand(UserInfoDto userInfo) => UserInfo = userInfo;

    public int Id { get; set; }

    public bool IsAvailable { get; set; }
    public required string Name { get; set; }
    public required string ManufactureEmail { get; set; }
    public required string ManufacturePhone { get; set; }
    public DateTime ProduceDate { get; set; }
}