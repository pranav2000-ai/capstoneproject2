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
    public class TransactionMapController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TransactionMapController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TransactionMap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_TransactionMap>>> Gettbl_TransactionMaps()
        {
            return await _context.tbl_TransactionMaps.ToListAsync();
        }

        // GET: api/TransactionMap/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_TransactionMap>> Gettbl_TransactionMap(int id)
        {
            var tbl_TransactionMap = await _context.tbl_TransactionMaps.FindAsync(id);

            if (tbl_TransactionMap == null)
            {
                return NotFound();
            }

            return tbl_TransactionMap;
        }

        // PUT: api/TransactionMap/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_TransactionMap(int id, tbl_TransactionMap tbl_TransactionMap)
        {
            if (id != tbl_TransactionMap.TranTypeId)
            {
                return BadRequest();
            }

            _context.Entry(tbl_TransactionMap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_TransactionMapExists(id))
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

        // POST: api/TransactionMap
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_TransactionMap>> Posttbl_TransactionMap(tbl_TransactionMap tbl_TransactionMap)
        {
            _context.tbl_TransactionMaps.Add(tbl_TransactionMap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_TransactionMap", new { id = tbl_TransactionMap.TranTypeId }, tbl_TransactionMap);
        }

        // DELETE: api/TransactionMap/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_TransactionMap(int id)
        {
            var tbl_TransactionMap = await _context.tbl_TransactionMaps.FindAsync(id);
            if (tbl_TransactionMap == null)
            {
                return NotFound();
            }

            _context.tbl_TransactionMaps.Remove(tbl_TransactionMap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_TransactionMapExists(int id)
        {
            return _context.tbl_TransactionMaps.Any(e => e.TranTypeId == id);
        }
    }
}
