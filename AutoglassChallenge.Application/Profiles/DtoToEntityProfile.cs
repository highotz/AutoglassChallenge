using AutoglassChallenge.Application.HttpHandlers.Product;
using AutoglassChallenge.Domain.DTOs;
using AutoglassChallenge.Domain.Entities;
using AutoMapper;

namespace AutoglassChallenge.Application.Profiles
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {

            CreateMap<Product, ProductDto>();
            CreateMap<ProductRequest, ProductDto>();

            CreateMap<ProductDto, Product>();
            CreateMap<ProductDto, ProductResponse>();

        }
    }
}
