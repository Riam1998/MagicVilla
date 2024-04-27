using AutoMapper;
using Prueba_Web.Models.Dto;

namespace Prueba_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<PruebaDto, PruebaCreateDto>();
            CreateMap<PruebaDto, PruebaUpdateDto>();
            CreateMap<NumeroVillaDto, NumeroVillaCreateDto>();
            CreateMap<NumeroVillaDto, NumeroVillaUpdateDto>();
        }
    }
}
