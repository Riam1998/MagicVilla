using prueba1._0.Datos;
using prueba1._0.Modelos;
using prueba1._0.Repositorio.IRepositorio;

namespace prueba1._0.Repositorio
{
    public class PruebaRepositorio : Repositorio<Prueba>, IPruebaRepositorio
    {

        private readonly ApplicationDbContext _db;

        public PruebaRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        public async Task<Prueba> Actualizar(Prueba entidad)
        {
            entidad.FechaActualizacion = DateTime.Now;
            _db.Villas.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}
