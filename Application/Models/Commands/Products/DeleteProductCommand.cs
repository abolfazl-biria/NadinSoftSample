using Common.Dtos;
using MediatR;

namespace Application.Models.Commands.Products;

public class DeleteProductCommand : RequestBaseDto, IRequest<ResultDto>
{
    public DeleteProductCommand(UserInfoDto userInfo) => UserInfo = userInfo;

    public int Id { get; set; }
}