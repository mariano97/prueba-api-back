using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaApi.Service;
using PruebaApi.Service.Mappers.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private IProductoService _service;

        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAllProductos()
        {
            try
            {
                var lista = await _service.ConsultarAll();
                return Ok(lista);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostCrear([FromBody]ProdyctoDTO prodyctoDTO)
        {
            try
            {
                if (prodyctoDTO == null || prodyctoDTO.Idprodyctos != 0)
                    throw new ArgumentNullException(paramName: "prodyctoDTO", message: "Argumento Nulo");
                var prodycto = await _service.Guardar(prodyctoDTO);
                return Ok(prodycto);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var producto = await _service.ConsultarById(id);
                return Ok(producto);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

