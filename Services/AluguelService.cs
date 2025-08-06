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
    public class AluguelService : IAluguelService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AluguelService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AluguelDetalhesDTO> ConsultarLocacaoPorIdAsync(int id)
        {
            var aluguel = await _context.Alugueis.FindAsync(id);
            if (aluguel == null) return null;

            return _mapper.Map<AluguelDetalhesDTO>(aluguel);
        }

        public async Task<bool> DeletarLocacaoPorIdAsync(int id)
        {
            var aluguel = await _context.Alugueis.FindAsync(id);
            if (aluguel == null) return false;

            _context.Remove(aluguel);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<AluguelDetalhesDTO>> ListarLocacoesAsync()
        {
            var aluguel = await _context.Alugueis.ToListAsync();
            if (aluguel == null) return null;

            return _mapper.Map<IEnumerable<AluguelDetalhesDTO>>(aluguel);
        }

        public async Task<AluguelDTO> RealizarLocacaoAsync(AluguelDTO dto)
        {
            var aluguel = _mapper.Map<Aluguel>(dto);
            _context.Alugueis.Add(aluguel);

            await _context.SaveChangesAsync();
            return _mapper.Map<AluguelDTO>(aluguel);
        }
    }
}