using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos;

namespace Biblioteca.Interfaces
{
    public interface IAluguelService
    {
        Task<AluguelDTO> RealizarLocacaoAsync(AluguelDTO dto);

        Task<IEnumerable<AluguelDetalhesDTO>> ListarLocacoesAsync();

        Task<AluguelDetalhesDTO> ConsultarLocacaoPorIdAsync(int id);

        Task<bool> DeletarLocacaoPorIdAsync(int id);


    }
}