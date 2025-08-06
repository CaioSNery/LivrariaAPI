using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos;
using Biblioteca.Interfaces;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCliente(ClienteDTO dto)
        {
            var resultado = await _service.CriarCadastroClienteAsync(dto);
            return Ok(resultado);

        }

        [HttpGet]
        public async Task<IActionResult> ListarClientes()
        {
            var resultado = await _service.ListarClientesAsync();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarClientePorId(int id)
        {
            var cliente = await _service.BuscarClientePorId(id);
            if (cliente == null) return NotFound();

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCliente(int id, Cliente upcliente)
        {
            var cliente = await _service.AtualizarCadastroClienteAsync(id, upcliente);
            if (cliente == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCliente(int id)
        {
            var cliente = await _service.DeletarCadastroClienteAsync(id);
            if (!cliente) return NotFound();

            return NoContent();
        }
    }
}