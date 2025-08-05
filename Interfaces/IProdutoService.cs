using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDetalhesDto>> ListarProdutosAsync();

        Task<ProdutoDTO> AddProdutoAsync(ProdutoDTO dto);

        Task<bool> DeletarProdutosAsyn(int id);

        Task<Produto> AtualizarProdutoAsync(int id, Produto produtoupdate);

        Task<ProdutoDetalhesDto> BuscarProdutoPorIdAsync(int id);
    }
}