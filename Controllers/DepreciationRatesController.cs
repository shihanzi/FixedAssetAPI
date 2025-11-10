using FixedAssetAPI.Data;
using FixedAssetAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FixedAssetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepreciationRatesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DepreciationRatesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepreciationRate>>> GetDepreciationRates()
        {
            return await _context.DepreciationRates
                .Include(d => d.Category)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepreciationRate>> GetDepreciationRate(int id)
        {
            var rate = await _context.DepreciationRates
                .Include(d => d.Category)
                .FirstOrDefaultAsync(d => d.DepreciationRateId == id);

            if (rate == null)
                return NotFound();

            return rate;
        }

        [HttpPost]
        public async Task<ActionResult<DepreciationRate>> PostDepreciationRate(DepreciationRate rate)
        {
            // Optional: validate category exists
            var categoryExists = await _context.Categories.AnyAsync(c => c.CategoryId == rate.CategoryId);
            if (!categoryExists)
                return BadRequest("Invalid CategoryId");

            _context.DepreciationRates.Add(rate);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepreciationRate), new { id = rate.DepreciationRateId }, rate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepreciationRate(int id, DepreciationRate rate)
        {
            if (id != rate.DepreciationRateId)
                return BadRequest("ID mismatch");

            _context.Entry(rate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.DepreciationRates.Any(e => e.DepreciationRateId == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepreciationRate(int id)
        {
            var rate = await _context.DepreciationRates.FindAsync(id);
            if (rate == null)
                return NotFound();

            _context.DepreciationRates.Remove(rate);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
