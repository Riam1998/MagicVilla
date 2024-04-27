using prueba1._0.Modelos;

namespace prueba1._0.Repositorio.IRepositorio
{
    public interface IPruebaRepositorio : IRepositorio<Prueba>
    {
        Task<Prueba> Actualizar(Prueba entidad);
    }
}
