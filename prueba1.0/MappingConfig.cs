using AutoMapper;
using prueba1._0.Modelos;
using prueba1._0.Modelos.Dto;

namespace prueba1._0
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            // se puede realizar de esa forma
            //CreateMap<Prueba, PruebaDto>();
            //CreateMap<PruebaDto, Prueba>();

            // o simplemente realizarlo en una sola linea de código
            CreateMap<Prueba, PruebaDto>().ReverseMap();
            CreateMap<Prueba, PruebaCreateDto>().ReverseMap();
            CreateMap<Prueba, PruebaUpdateDto>().ReverseMap();

            CreateMap<NumeroVilla, NumeroVillaDto>().ReverseMap();
            CreateMap<NumeroVilla, NumeroVillaCreateDto>().ReverseMap();
            CreateMap<NumeroVilla, NumeroVillaUpdateDto>().ReverseMap();
        }

    }
}
