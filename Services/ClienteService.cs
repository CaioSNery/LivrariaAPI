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
    public class ClienteService : IClienteService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClienteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<Cliente> AtualizarCadastroClienteAsync(int id, Cliente upcliente)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return null;

            cliente.Nome = upcliente.Nome;
            cliente.Cpf = upcliente.Cpf;
            cliente.Telefone = upcliente.Telefone;

            _context.Clientes.Add(upcliente);
            await _context.SaveChangesAsync();

            return upcliente;
        }

        public async Task<Cliente> BuscarClientePorId(int id)
        {
            var cliente = await _context.Clientes.Where(c => c.Id == id)
            .FirstOrDefaultAsync();
            if (cliente == null) return null;

            return cliente;
        }

        public async Task<ClienteDTO> CriarCadastroClienteAsync(ClienteDTO dto)
        {
            var cliente = new Cliente
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                Telefone = dto.Telefone

            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return _mapper.Map<ClienteDTO>(cliente);

        }

        public async Task<bool> DeletarCadastroClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ClienteDetalhesDTO>> ListarClientesAsync()
        {
            var cliente = await _context.Clientes.ToListAsync();
            return _mapper.Map<IEnumerable<ClienteDetalhesDTO>>(cliente);
        }
    }
}