using Prueba_Web.Models;

namespace Prueba_Web.Services.IServices
{
    public interface IBaseService
    {
        public ApiResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
