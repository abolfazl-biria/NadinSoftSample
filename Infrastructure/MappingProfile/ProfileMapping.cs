using Application.Models.Dtos.Products;
using AutoMapper;
using Domain.Entities.Products;

namespace Infrastructure.MappingProfile;

public class ProfileMapping : Profile
{
    public ProfileMapping()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CreatorName, opt =>
                opt.MapFrom(src => src.Creator.UserName))
            .ForMember(dest => dest.UpdaterName, opt =>
                opt.MapFrom(src => src.Updater != null ? src.Updater.UserName : ""));

        CreateMap<ProductDto, Product>();
    }
}