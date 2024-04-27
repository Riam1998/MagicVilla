using System.Linq.Expressions;

namespace prueba1._0.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        Task Crear(T entidad);

        Task<List<T>> GetAll(Expression<Func<T, bool>>? filtro = null);

        Task<T> GetA(Expression<Func<T, bool>> filtro = null, bool tracked=true);

        Task Remove(T entidad);

        Task Grabar();

    }
}
