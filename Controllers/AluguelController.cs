using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos;
using Biblioteca.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AluguelController : ControllerBase
    {
        private readonly IAluguelService _service;
        public AluguelController(IAluguelService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarLocacao(AluguelDTO dto)
        {
            var resultado = await _service.RealizarLocacaoAsync(dto);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ListarLocacoes()
        {
            var resultado = await _service.ListarLocacoesAsync();
            return Ok(resultado);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarLocacaoPorId(int id)
        {
            var resultado = await _service.ConsultarLocacaoPorIdAsync(id);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarLocacao(int id)
        {
            var resultado = await _service.DeletarLocacaoPorIdAsync(id);
            return NoContent();
        }


    }
}