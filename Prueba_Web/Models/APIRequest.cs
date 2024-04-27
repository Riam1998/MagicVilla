using static Prueba_Utilidad.DS;

namespace Prueba_Web.Models
{
    public class APIRequest
    {
        public APITipo APITipo { get; set; } = APITipo.GET;
        public string Url { get; set; }
        public object Datos  { get; set; }

    }
}
