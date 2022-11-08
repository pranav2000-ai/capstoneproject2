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
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TransactionsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_Transactions>>> Gettbl_Transactions()
        {
            return await _context.tbl_Transactions.ToListAsync();
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_Transactions>> Gettbl_Transactions(int id)
        {
            var tbl_Transactions = await _context.tbl_Transactions.FindAsync(id);

            if (tbl_Transactions == null)
            {
                return NotFound();
            }

            return tbl_Transactions;
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_Transactions(int id, tbl_Transactions tbl_Transactions)
        {
            if (id != tbl_Transactions.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(tbl_Transactions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_TransactionsExists(id))
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

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_Transactions>> Posttbl_Transactions(tbl_Transactions tbl_Transactions)
        {
            _context.tbl_Transactions.Add(tbl_Transactions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_Transactions", new { id = tbl_Transactions.TransactionId }, tbl_Transactions);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_Transactions(int id)
        {
            var tbl_Transactions = await _context.tbl_Transactions.FindAsync(id);
            if (tbl_Transactions == null)
            {
                return NotFound();
            }

            _context.tbl_Transactions.Remove(tbl_Transactions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_TransactionsExists(int id)
        {
            return _context.tbl_Transactions.Any(e => e.TransactionId == id);
        }
    }
}
