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
    public class LivrariaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LivrariaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Livraria>> PutLivros(Livraria livraria)
        {
            _context.Livraria.Add(livraria);
            await _context.SaveChangesAsync();
            return Ok(livraria);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livraria>>> GetLivraria()
        {
            var livraria = await _context.Livraria.ToListAsync();
            return Ok(livraria);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livraria>> GetIdLivraria(int id)
        {
            var livraria = await _context.Livraria.FindAsync(id);
            if (livraria == null)
            {
                return NotFound();
            }
            return Ok(livraria);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Livraria>> LivrariaUpdate(int id, [FromBody] Livraria livrariaup)
        {
            if (id != livrariaup.Id)
            {
                return BadRequest();
            }
            _context.Livraria.Update(livrariaup);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Livraria>> RemoveLivraria(int id)
        {
            var livraria = _context.Livraria.Find(id);
            if (livraria == null)
            {
                return NotFound();
            }
            _context.Livraria.Remove(livraria);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        



    }
}