using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinalAPI.Data.Models;
using MinalAPI.Domain;

namespace MinalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NavioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NavioController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca todos os navios.
        /// </summary>
        /// <returns>A lista dos navios.</returns>
        /// <response code="200">Retorna a lista dos navios</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Navio>>> GetNavios()
        {
            return await _context.Navios.ToListAsync();
        }

        /// <summary>
        /// Busca um navio específico pelo ID.
        /// </summary>
        /// <param name="id">O ID do navio que será buscado.</param>
        /// <returns>O navio com um ID específico.</returns>
        /// <response code="200">Se o navio for encontrado</response>
        /// <response code="404">Se o navio não for encontrado</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Navio>> GetNavio(int id)
        {
            var navio = await _context.Navios.FindAsync(id);

            if (navio == null)
            {
                return NotFound();
            }

            return navio;
        }

        /// <summary>
        /// Atualiza um navio específico.
        /// </summary>
        /// <param name="id">ID do navio para ser atualizado.</param>
        /// <param name="navioDto">O dado atualizado do navio.</param>
        /// <returns>Status indicando sucesso ou falha da requisição.</returns>
        /// <response code="204">Se a atualização foi um sucesso</response>
        /// <response code="400">Se o dado fornecido é inválido</response>
        /// <response code="404">Se o navio não foi encontrado</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNavio(int id, NavioDTO navioDto)
        {
            if (navioDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var navio = await _context.Navios.FindAsync(id);
            if (navio == null)
            {
                return NotFound();
            }

            navio.Nome = navioDto.Nome;
            navio.TipoNavio = navioDto.TipoNavio;
            navio.CapacidadeLastro = navioDto.CapacidadeLastro;

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

        /// <summary>
        /// Cria um novo navio.
        /// </summary>
        /// <param name="navioDto">Os dados no navio que será criado.</param>
        /// <returns>O navio criado.</returns>
        /// <response code="201">Retorna o novo navio criado.</response>
        [HttpPost]
        public async Task<ActionResult<Navio>> PostNavio(NavioDTO navioDto)
        {
            var navio = new Navio
            {
                Nome = navioDto.Nome,
                TipoNavio = navioDto.TipoNavio,
                CapacidadeLastro = navioDto.CapacidadeLastro
            };

            _context.Navios.Add(navio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNavio", new { id = navio.IdNavio }, navio);
        }

        /// <summary>
        /// Deleta um navio específico.
        /// </summary>
        /// <param name="id">O ID do navio que será deletado.</param>
        /// <returns>Status indicando sucesso ou falha da requisição.</returns>
        /// <response code="204">Se a deleção for um sucesso</response>
        /// <response code="404">Se o navio não for encontrado</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNavio(int id)
        {
            var navio = await _context.Navios.FindAsync(id);
            if (navio == null)
            {
                return NotFound();
            }

            _context.Navios.Remove(navio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NavioExists(int id)
        {
            return _context.Navios.Any(e => e.IdNavio == id);
        }
    }
}
