using System;
namespace PruebaApi.Service.Mappers.Dtos
{
	public class ProdyctoDTO
	{
        public int Idprodyctos { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal Costo { get; set; }
    }
}

