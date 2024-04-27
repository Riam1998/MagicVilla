using prueba1._0.Datos;
using prueba1._0.Modelos;
using prueba1._0.Repositorio.IRepositorio;

namespace prueba1._0.Repositorio
{
    public class NVillaRepositorio : Repositorio<NumeroVilla>, INumeroVillaRepositorio
    {

        private readonly ApplicationDbContext _db;

        public NVillaRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        public async Task<NumeroVilla> Actualizar(NumeroVilla entidad)
        {
            entidad.FechaActualizacion = DateTime.Now;
            _db.NumeroVillas.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}
