using System.ComponentModel.DataAnnotations;

namespace Prueba_Web.Models.Dto
{
    public class PruebaCreateDto
    {
        [Required(ErrorMessage = "El Campo Nombre es Requerido")]
        [MaxLength(30)]
        public string Nombre { get; set; }
        public string Detalle { get; set; }

        [Required(ErrorMessage = "EL Campo Tarifa es Requerido")]
        public double Tarifa { get; set; }
        [Required(ErrorMessage="El campo Ocupantes es Requerido")]
        public int Ocupantes { get; set; }
        [Required(ErrorMessage = "El campo Metros Cuadrados es Requerido")]
        public double MetrosCuadrados { get; set; }
        public string ImagenUrl { get; set; }
        public string Amenidad { get; set; }
    }
}
