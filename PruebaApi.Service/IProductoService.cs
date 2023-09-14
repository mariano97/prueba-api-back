using System;
using PruebaApi.Service.Mappers.Dtos;

namespace PruebaApi.Service
{
	public interface IProductoService
	{

		Task<ProdyctoDTO> Guardar(ProdyctoDTO prodyctoDTO);
		Task<ProdyctoDTO> ConsultarById(int id);
		Task<IEnumerable<ProdyctoDTO>> ConsultarAll();

	}
}

