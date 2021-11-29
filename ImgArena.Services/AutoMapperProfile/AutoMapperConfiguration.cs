using AutoMapper;
using ImgArena.Models.DTOs;

namespace ImgArena.Services.AutoMapperConfiguration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataStorage.Product.Product, ProductDto>()
                .ReverseMap();

            CreateMap<CreateProductDto, DataStorage.Product.Product>();
        }
    }
}
