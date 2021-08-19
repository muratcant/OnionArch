using AutoMapper;
using OnionArch.Application.DTO;
using OnionArch.Application.Features.Commands.AddProduct;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ProductViewDto>().ReverseMap();

            CreateMap<Product, AddProductCommand>().ReverseMap(); //Yapılan dönüşümü belirttik.
        }
    }
}
