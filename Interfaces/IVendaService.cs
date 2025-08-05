using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos;
using Biblioteca.Models;

namespace Biblioteca.Interfaces
{
    public interface IVendaService
    {
        Task<object> RealizarVendaAsync(VendaDTO dto);

        Task<IEnumerable<VendaResponseDTO>> ListarVendasAsync();

        Task<VendaResponseDTO> BuscarVendaPorIdAsync(int id);
    }
}