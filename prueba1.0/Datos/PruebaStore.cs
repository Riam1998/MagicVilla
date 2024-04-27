using prueba1._0.Modelos.Dto;

namespace prueba1._0.Datos
{
    public static class PruebaStore
    {
        public static List<PruebaDto> pruebaList = new List<PruebaDto>
        {
               new PruebaDto{Id=1, Nombre="Vista a la Playa" },
               new PruebaDto{Id=2, Nombre="Vista a la Piscina"},
        };
    }
}
