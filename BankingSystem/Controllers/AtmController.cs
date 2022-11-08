using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankingSystem.Model;

namespace BankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtmController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AtmController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Atm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_Atmdtls>>> Gettbl_Atmdtls()
        {
            return await _context.tbl_Atmdtls.ToListAsync();
        }

        // GET: api/Atm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbl_Atmdtls>> GetTbl_Atmdtls(int id)
        {
            var tbl_Atmdtls = await _context.tbl_Atmdtls.FindAsync(id);

            if (tbl_Atmdtls == null)
            {
                return NotFound();
            }

            return tbl_Atmdtls;
        }

        // PUT: api/Atm/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbl_Atmdtls(int id, Tbl_Atmdtls tbl_Atmdtls)
        {
            if (id != tbl_Atmdtls.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbl_Atmdtls).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_AtmdtlsExists(id))
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

        // POST: api/Atm
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbl_Atmdtls>> PostTbl_Atmdtls(Tbl_Atmdtls tbl_Atmdtls)
        {
            _context.tbl_Atmdtls.Add(tbl_Atmdtls);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbl_Atmdtls", new { id = tbl_Atmdtls.Id }, tbl_Atmdtls);
        }

        // DELETE: api/Atm/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbl_Atmdtls(int id)
        {
            var tbl_Atmdtls = await _context.tbl_Atmdtls.FindAsync(id);
            if (tbl_Atmdtls == null)
            {
                return NotFound();
            }

            _context.tbl_Atmdtls.Remove(tbl_Atmdtls);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Tbl_AtmdtlsExists(int id)
        {
            return _context.tbl_Atmdtls.Any(e => e.Id == id);
        }
    }
}
