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
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AccountsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_Accounts>>> Gettbl_Accounts()
        {
            return await _context.tbl_Accounts.ToListAsync();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_Accounts>> Gettbl_Accounts(int id)
        {
            var tbl_Accounts = await _context.tbl_Accounts.FindAsync(id);

            if (tbl_Accounts == null)
            {
                return NotFound();
            }

            return tbl_Accounts;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_Accounts(int id, tbl_Accounts tbl_Accounts)
        {
            if (id != tbl_Accounts.AccTypeId)
            {
                return BadRequest();
            }

            _context.Entry(tbl_Accounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_AccountsExists(id))
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

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_Accounts>> Posttbl_Accounts(tbl_Accounts tbl_Accounts)
        {
            _context.tbl_Accounts.Add(tbl_Accounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_Accounts", new { id = tbl_Accounts.AccTypeId }, tbl_Accounts);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_Accounts(int id)
        {
            var tbl_Accounts = await _context.tbl_Accounts.FindAsync(id);
            if (tbl_Accounts == null)
            {
                return NotFound();
            }

            _context.tbl_Accounts.Remove(tbl_Accounts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_AccountsExists(int id)
        {
            return _context.tbl_Accounts.Any(e => e.AccTypeId == id);
        }
    }
}
