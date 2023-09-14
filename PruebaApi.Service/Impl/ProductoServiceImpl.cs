using System;
using AutoMapper;
using PruebaApi.Data.Models;
using PruebaApi.Domain.Repositories;
using PruebaApi.Service.Mappers.Dtos;

namespace PruebaApi.Service.Impl
{
	public class ProductoServiceImpl : IProductoService
	{

		private IMapper _mapper;
		private IRepositoryAsync<Prodycto> _repository;

		public ProductoServiceImpl(IRepositoryAsync<Prodycto> repository, IMapper mapper)
		{
			_mapper = mapper;
			_repository = repository;
		}

        public async Task<IEnumerable<ProdyctoDTO>> ConsultarAll()
        {
            var lista = await _repository.ConsultarAll();
            var listaDTO = _mapper.Map<IEnumerable<ProdyctoDTO>>(lista);
            return listaDTO;
        }

        public async Task<ProdyctoDTO> ConsultarById(int id)
        {
            var producto = await _repository.ConsultarById(id);
            return _mapper.Map<ProdyctoDTO>(producto);
        }

        public async Task<ProdyctoDTO> Guardar(ProdyctoDTO prodyctoDTO)
        {
            var producto = _mapper.Map<Prodycto>(prodyctoDTO);
            producto = await _repository.Guardar(producto);
            return _mapper.Map<ProdyctoDTO>(producto);
        }
    }
}

