using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public VendasController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost("{id}")]
        public IActionResult RealizarVendas(int id, [FromBody] VendaDTO dto)
        {
            var livros = _appDbContext.Livraria.FirstOrDefault(l => l.Id == dto.LivrariaId);
            if (livros == null)
            {
                return NotFound();
            }

            if (livros.Estoque < dto.Quantidade)
            {
                return BadRequest("Produto sem Estoque");
            }

            decimal valorUnitario = livros.ValorVenda;
            decimal valorTotal = valorUnitario * dto.Quantidade;
            


            var vendas = new Vendas
            {
                IdProduto = livros.Id,
                NomeProduto = livros.Nome,
                QuantidadeVendida = dto.Quantidade,
                ValorUnitario = valorUnitario,
                ValorTotal = valorTotal,
                DataVenda = dto.DataVenda

            };

            livros.Estoque -= dto.Quantidade;

            _appDbContext.Vendas.Add(vendas);
            _appDbContext.SaveChangesAsync();

            var response = new VendaResponseDTO
            {
                Mensagem = "Venda Realizada Com sucesso !",
                Produto = livros.Nome,
                QuantidadeVendida = dto.Quantidade,
                ValorTotal = valorTotal,
                DataVenda = dto.DataVenda
            };

            return Ok(response);
            

        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendas>>> GetVendas()
        {
            var vendas = await _appDbContext.Vendas.ToListAsync();
            return Ok(vendas);
        }
    }
}