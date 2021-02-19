using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YoutubeTutorial.Models;

namespace YoutubeTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BagController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public BagController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: api/Bag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bag>>> GetBags()
        {
            return await _context.Bags.ToListAsync();
        }

        // GET: api/Bag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bag>> GetBag(int id)
        {
            var bag = await _context.Bags.FindAsync(id);

            if (bag == null)
            {
                return NotFound();
            }

            return bag;
        }

        // PUT: api/Bag/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBag(int id, Bag bag)
        {
            if (id != bag.Id)
            {
                return BadRequest();
            }

            _context.Entry(bag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagExists(id))
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

        // POST: api/Bag
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bag>> PostBag(Bag bag)
        {
            _context.Bags.Add(bag);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BagExists(bag.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBag", new { id = bag.Id }, bag);
        }

        // DELETE: api/Bag/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBag(int id)
        {
            var bag = await _context.Bags.FindAsync(id);
            if (bag == null)
            {
                return NotFound();
            }

            _context.Bags.Remove(bag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BagExists(int id)
        {
            return _context.Bags.Any(e => e.Id == id);
        }
    }
}
