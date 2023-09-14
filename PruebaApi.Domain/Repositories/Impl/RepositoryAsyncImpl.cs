using System;
using Microsoft.EntityFrameworkCore;
using PruebaApi.Data.DBConfiguration;

namespace PruebaApi.Domain.Repositories.Impl
{
	public class RepositoryAsyncImpl<T> : IRepositoryAsync<T> where T : class
	{

        protected DataBaseContext _dataBaseContext;

        private bool _dispose = false;

		public RepositoryAsyncImpl(DataBaseContext dataBaseContext)
		{
            _dataBaseContext = dataBaseContext;
		}

        public async Task<IEnumerable<T>> ConsultarAll()
        {
            return await EntitySet.ToListAsync<T>();
        }

        public async Task<T> ConsultarById(int id)
        {
            return await EntitySet.FindAsync(id);
        }

        public void Dispose(bool isDisposing)
        {
            if (!_dispose && isDisposing)
            {
                _dataBaseContext.Dispose();
            }
            _dispose = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<T> Guardar(T entity)
        {
            await EntitySet.AddAsync(entity);
            await Save();
            return entity; 
        }

        protected DbSet<T> EntitySet
        {
            get
            {
                return _dataBaseContext.Set<T>();
            }
        }

        protected async Task<int> Save()
        {
            var result = await _dataBaseContext.SaveChangesAsync();
            return result;
        }
    }
}

