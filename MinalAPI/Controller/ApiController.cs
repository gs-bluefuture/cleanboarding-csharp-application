using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaApiCrud.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ShipContext _context;

        public ApiController(ShipContext context)
        {
            _context = context;
        }

  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Navio>>> GetNavios()
        {
            return await _context.Navio
                .Include(n => n.OperacoesLastro)
                .Include(n => n.HistoricoLocalizacoes)
                .Include(n => n.MonitoramentosOperacao)
                .ToListAsync();
        }

        // GET: api/Navios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Navio>> GetNavio(int id)
        {
            var navio = await _context.Navio
                .Include(n => n.OperacoesLastro)
                .Include(n => n.HistoricoLocalizacoes)
                .Include(n => n.MonitoramentosOperacao)
                .FirstOrDefaultAsync(n => n.IdNavio == id);

            if (navio == null)
            {
                return NotFound();
            }

            return navio;
        }

        [HttpPost]
        public async Task<ActionResult<Navio>> PostNavio(Navio navio)
        {
            _context.Navio.Add(navio);
            Console.WriteLine("Tetse", navio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNavio), new { id = navio.IdNavio }, navio);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNavio(int id, Navio navio)
        {
            if (id != navio.IdNavio)
            {
                return BadRequest();
            }

            _context.Entry(navio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NavioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNavio(int id)
        {
            var navio = await _context.Navio.FindAsync(id);
            if (navio == null)
            {
                return NotFound();
            }

            _context.Navio.Remove(navio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NavioExists(int id)
        {
            return _context.Navio.Any(e => e.IdNavio == id);
        }
    }
}
