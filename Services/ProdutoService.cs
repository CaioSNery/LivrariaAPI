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
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public ProdutoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProdutoDTO> AddProdutoAsync(ProdutoDTO dto)
        {
            var produto = new Produto
            {

                Nome = dto.Nome,
                Ano = dto.Ano,
                ValorVenda = dto.ValorVenda,
                ValorCompra = dto.ValorCompra,
                Estoque = dto.Estoque,
                Tipo = dto.Tipo


            };

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProdutoDTO>(produto);


        }

        public async Task<Produto> AtualizarProdutoAsync(int id, Produto produtoupdate)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return null;

            produto.Nome = produtoupdate.Nome;
            produto.Tipo = produtoupdate.Tipo;
            produto.ValorVenda = produtoupdate.ValorVenda;
            produto.Ano = produtoupdate.Ano;
            produto.ValorVenda = produtoupdate.ValorVenda;

            _context.Update(produtoupdate);
            await _context.SaveChangesAsync();

            return produtoupdate;

        }

        public async Task<ProdutoDetalhesDto> BuscarProdutoPorIdAsync(int id)
        {
            var produto = await _context.Produtos.Where(p => p.Id == id)
            .FirstOrDefaultAsync();
            if (produto == null) return null;

            return _mapper.Map<ProdutoDetalhesDto>(produto);
        }

        public async Task<bool> DeletarProdutosAsyn(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return false;

            _context.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProdutoDetalhesDto>> ListarProdutosAsync()
        {
            var produto = await _context.Produtos.ToListAsync();

            return _mapper.Map<IEnumerable<ProdutoDetalhesDto>>(produto);
        }
    }
}