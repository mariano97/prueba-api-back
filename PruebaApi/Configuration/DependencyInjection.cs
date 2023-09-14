using Microsoft.EntityFrameworkCore;
using PruebaApi.Data.DBConfiguration;
using PruebaApi.Data.Models;
using PruebaApi.Domain.Repositories;
using PruebaApi.Domain.Repositories.Impl;
using PruebaApi.Service;
using PruebaApi.Service.Impl;
using PruebaApi.Service.Mappers.Profiles;

namespace PruebaApi.Configuration
{
	public static class DependencyInjection
	{

		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
		{

			var connectionDataBase = configuration.GetConnectionString("MySqlConnection");
			services.AddDbContext<DataBaseContext>(opt =>
			{
				opt.UseMySql(connectionDataBase, ServerVersion.AutoDetect(connectionDataBase));
			});

			services.AddAutoMapper(typeof(ProdyctoProfile));

			services.AddScoped<IRepositoryAsync<Prodycto>, RepositoryAsyncImpl<Prodycto>>();
			services.AddScoped<IProductoService, ProductoServiceImpl>();

			return services;
		}

	}
}

