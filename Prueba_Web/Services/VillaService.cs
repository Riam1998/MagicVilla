using Prueba_Web.Models.Dto;
using Prueba_Web.Models;
using Prueba_Web.Services.IServices;
using static Prueba_Utilidad.DS;
using Prueba_Utilidad;
using System.Configuration;
using System.Net.Http;

namespace Prueba_Web.Services
{
     public class VillaService : BaseService, IVillaService
    {
        public readonly IHttpClientFactory _httpClient;
        private string _villaUrl;
        public VillaService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            _httpClient = httpClient;
            _villaUrl = configuration.GetValue<string>("ServiceUrls:API_URL");
        }
        public Task<T> Actualizar<T>(PruebaUpdateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.PUT,
                Datos = dto,
                Url = _villaUrl + "/api/Prueba/" + dto.Id
            });
        }

        public Task<T> Crear<T>(PruebaCreateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.POST,
                Datos = dto,
                Url= _villaUrl+ "/api/Prueba"
            });
        }

        public Task<T> Obtener<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.GET,
                Url = _villaUrl + "/api/Prueba/" + id
            });
        }

        public Task<T> ObtenerT<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.GET,
                Url = _villaUrl + "/api/Prueba"
            });
        }

        public Task<T> Remover<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.DELETE,
                Url = _villaUrl + "/api/Prueba/" + id
            });
        }
    }
}
