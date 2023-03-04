﻿using System;
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
    public class CodicesController : ControllerBase
    {
        private readonly DataContext _context;

        public CodicesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Codices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Codex>>> GetCodexes()
        {
          if (_context.Codexes == null)
          {
              return NotFound();
          }
            return await _context.Codexes.ToListAsync();
        }

        // GET: api/Codices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Codex>> GetCodex(long id)
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

            return codex;
        }

        // PUT: api/Codices/5
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

        // POST: api/Codices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Codex>> PostCodex(Codex codex)
        {
          if (_context.Codexes == null)
          {
              return Problem("Entity set 'DataContext.Codexes'  is null.");
          }
            _context.Codexes.Add(codex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCodex", new { id = codex.Id }, codex);
        }

        // DELETE: api/Codices/5
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

            return NoContent();
        }

        private bool CodexExists(long id)
        {
            return (_context.Codexes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
