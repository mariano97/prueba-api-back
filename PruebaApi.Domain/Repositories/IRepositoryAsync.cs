using System;
namespace PruebaApi.Domain.Repositories
{
	public interface IRepositoryAsync<T> : IDisposable where T : class
	{

		Task<T> Guardar(T entity);
		Task<T> ConsultarById(int id);
		Task<IEnumerable<T>> ConsultarAll();

	}
}

