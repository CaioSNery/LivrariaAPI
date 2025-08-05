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
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduto([FromBody] ProdutoDTO dto)
        {
            var resultado = await _service.AddProdutoAsync(dto);
            return Ok(resultado);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarProdutoid(int id)
        {
            var resultado = await _service.BuscarProdutoPorIdAsync(id);
            if (resultado == null) return NotFound();
            return Ok(resultado);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, [FromBody] Produto produtoupdate)
        {
            var resultado = await _service.AtualizarProdutoAsync(id, produtoupdate);
            if (resultado == null) return NotFound();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarProdutoPorId(int id)
        {
            var produto = await _service.DeletarProdutosAsyn(id);
            if (!produto) return NotFound();
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ListarProdutos()
        {
            var resultado = await _service.ListarProdutosAsync();
            if (resultado == null) return NotFound();
            return Ok(resultado);
        }






    }
}