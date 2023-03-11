using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using codeallot.Data;
using codeallot.Models;

namespace codeallot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodexController : ControllerBase
    {
        private readonly DataContext _context;

        public CodexController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Codex
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Codex>>> GetCodexes()
        {
            if (_context.Codexes == null)
            {
                return NotFound();
            }
            return await _context.Codexes.ToListAsync();
            //return await _context.Codexes.Include(c => ).ToListAsync();
        }

        // GET: api/Codex/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Codex>> GetCodex(long id)
        {
            if (_context.Codexes == null)
            {
                return NotFound();
            }
            //var codex = await _context.Codexes.FindAsync(id);
            var codex = await _context.Codexes.FirstOrDefaultAsync(c => c.Id == id);
            if (codex == null)
            {
                return NotFound();
            }

            return codex;
        }

        // PUT: api/Codex/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCodex(long id, Codex codex)
        {
            if (id != codex.Id)
            {
                return BadRequest();
            }

            _context.Entry(codex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodexExists(id))
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

        // POST: api/Codex
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Codex>> PostCodex(CreateCodex req)
        {
            if (_context.Codexes == null)
            {
                return Problem("Entity set 'DataContext.Codexes'  is null.");
            }
            if (req.userid == 0)
            {
                return Problem("Userid is null.");
            }

            var user = await _context.Users.FindAsync(req.userid);

            var newCodex = new Codex
            {
                Title = req.Title,
                Filename = req.Filename,
                Description = req.Description,
                Content = req.Content,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserName = user.Name,
            };

            if (user.CodexCount is null || user.CodexCount == 0)
            {
                user.CodexCount = 1;
                user.Codexes = new List<Codex> { newCodex };
            }
            else
            {
                user.CodexCount += 1;
                //user.Codexes.Add(newCodex);
            }


            _context.Codexes.Add(newCodex);
            _context.Users.Update(user);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCodex", newCodex.Id);
        }

        // DELETE: api/Codex/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCodex(long id)
        {
            if (_context.Codexes == null)
            {
                return NotFound();
            }
            var codex = await _context.Codexes.FindAsync(id);
            if (codex == null)
            {
                return NotFound();
            }

            _context.Codexes.Remove(codex);
            await _context.SaveChangesAsync();

            return Ok("Codex deleted.");
        }

        private bool CodexExists(long id)
        {
            return (_context.Codexes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
