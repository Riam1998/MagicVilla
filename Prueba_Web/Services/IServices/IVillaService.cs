using Prueba_Web.Models.Dto;

namespace Prueba_Web.Services.IServices
{
    public interface IVillaService
    {
        Task<T> ObtenerT<T>();
        Task<T> Obtener<T>(int id);
        Task<T> Crear<T>(PruebaCreateDto dto);
        Task<T> Actualizar<T>(PruebaUpdateDto dto);
        Task<T> Remover<T>(int id); 
    }
}
