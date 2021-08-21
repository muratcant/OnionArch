using AutoMapper;
using OnionArch.Application.DTO;
using OnionArch.Application.Features.Commands.AddProduct;
using OnionArch.Application.Features.Commands.UpdateProduct;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ProductViewDto>().ReverseMap();

            CreateMap<Product, AddProductCommand>().ReverseMap(); //Yapılan dönüşümü belirttik.

            CreateMap<Product, UpdateProductCommand>().ReverseMap();
        }
    }
}
