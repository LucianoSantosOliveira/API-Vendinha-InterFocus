using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Vendinha_InterFocus.Data;
using API_Vendinha_InterFocus.Model;

namespace API_Vendinha_InterFocus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DividasController : ControllerBase
    {
        private readonly API_Vendinha_InterFocusContext _context;

        public DividasController(API_Vendinha_InterFocusContext context)
        {
            _context = context;
        }

        // GET: api/Dividas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Divida>>> GetDivida()
        {
            return await _context.Divida.ToListAsync();
        }

        // GET: api/Dividas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Divida>> GetDivida(Guid id)
        {
            var divida = await _context.Divida.FindAsync(id);

            if (divida == null)
            {
                return NotFound();
            }

            return divida;
        }

        // PUT: api/Dividas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDivida(Guid id, Divida divida)
        {
            if (id != divida.DividaId)
            {
                return BadRequest();
            }

            _context.Entry(divida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DividaExists(id))
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

        // POST: api/Dividas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Divida>> PostDivida(Divida divida)
        {
            _context.Divida.Add(divida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDivida", new { id = divida.DividaId }, divida);
        }

        // DELETE: api/Dividas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDivida(Guid id)
        {
            var divida = await _context.Divida.FindAsync(id);
            if (divida == null)
            {
                return NotFound();
            }

            _context.Divida.Remove(divida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DividaExists(Guid id)
        {
            return _context.Divida.Any(e => e.DividaId == id);
        }
    }
}
