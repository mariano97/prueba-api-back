using System;
using AutoMapper;
using PruebaApi.Data.Models;
using PruebaApi.Service.Mappers.Dtos;

namespace PruebaApi.Service.Mappers.Profiles
{
	public class ProdyctoProfile : Profile
	{
		public ProdyctoProfile()
		{
			CreateMap<Prodycto, ProdyctoDTO>();
			CreateMap<ProdyctoDTO, Prodycto>();

        }
	}
}

