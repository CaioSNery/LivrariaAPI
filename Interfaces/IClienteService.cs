using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos;
using Biblioteca.Models;

namespace Biblioteca.Interfaces
{
    public interface IClienteService
    {
        Task<bool> DeletarCadastroClienteAsync(int id);

        Task<ClienteDTO> CriarCadastroClienteAsync(ClienteDTO dto);

        Task<IEnumerable<ClienteDetalhesDTO>> ListarClientesAsync();

        Task<Cliente> BuscarClientePorId(int id);

        Task<Cliente> AtualizarCadastroClienteAsync(int id, Cliente upcliente);



    }
}