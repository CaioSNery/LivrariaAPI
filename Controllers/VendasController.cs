using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Data;
using Biblioteca.Dtos;
using Biblioteca.Interfaces;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IVendaService _service;
        public VendasController(IVendaService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarVendaPorId(int id)
        {
            var resultado = await _service.BuscarVendaPorIdAsync(id);
            if (resultado == null) return NotFound("Venda não encontrada!");

            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ListarVendas()
        {
            var resultado = await _service.ListarVendasAsync();
            if (resultado == null) return NotFound();

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> RealizarVenda(VendaDTO dto)
        {
            var resultado = await _service.RealizarVendaAsync(dto);
            return Ok(resultado);

        }



    }


}