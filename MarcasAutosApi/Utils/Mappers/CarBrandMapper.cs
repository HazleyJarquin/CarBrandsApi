using AutoMapper;
using MarcasAutosApi.Dtos;
using MarcasAutosApi.Entities;

namespace MarcasAutosApi.Utils.Mappers
{
    public class CarBrandMapper : Profile
    {
        public CarBrandMapper()
        {
            CreateMap<CarBrandDto, CarBrand>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<CarBrand, CarBrandDto>();
        }
    }
}
