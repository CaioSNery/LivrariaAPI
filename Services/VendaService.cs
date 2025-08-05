using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Biblioteca.Data;
using Biblioteca.Dtos;
using Biblioteca.Interfaces;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    public class VendaService : IVendaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public VendaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<VendaResponseDTO> BuscarVendaPorIdAsync(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null) return null;

            return _mapper.Map<VendaResponseDTO>(venda);
        }

        public async Task<IEnumerable<VendaResponseDTO>> ListarVendasAsync()
        {
            var venda = await _context.Vendas.ToListAsync();
            return _mapper.Map<IEnumerable<VendaResponseDTO>>(venda);
        }

        public async Task<object> RealizarVendaAsync(VendaDTO dto)
        {
            var produto = await _context.Produtos.FindAsync(dto.IdProduto);
            if (produto == null) return "Produto não encontrado";
            if (produto.Estoque == 0) return "Estoque zerado";
            if (dto.QuantidadeVendida > produto.Estoque) return "Estoque insuficiente";

            decimal ValorFinal = dto.QuantidadeVendida * produto.ValorVenda;

            produto.Estoque -= dto.QuantidadeVendida;

            _context.Produtos.Update(produto);



            var venda = new Vendas
            {
                IdProduto = dto.IdProduto,
                NomeProduto = produto.Nome,
                QuantidadeVendida = dto.QuantidadeVendida,
                ValorTotal = ValorFinal,
                DataVenda = DateTime.Now

            };

            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            return new VendaResponseDTO
            {
                Mensagem = "Venda Realizada com Sucesso !",
                NomeProduto = produto.Nome,
                QuantidadeVendida = dto.QuantidadeVendida,
                ValorTotal = ValorFinal
            };



        }
    }
}