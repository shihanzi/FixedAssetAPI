using FixedAssetAPI.Data;
using FixedAssetAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FixedAssetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustodionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustodionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Custodian>>> GetAll()
        {
            return await _context.Custodians.Include(c => c.Department)
                 .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Custodian>> GetById(int id)
        {
            var custodian = await _context.Custodians
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.CustodianId == id);

            if (custodian == null)
                return NotFound();

            return custodian;
        }

        [HttpPost]
        public async Task<ActionResult<Custodian>> Create(Custodian custodian)
        {
            if (!await _context.Departments.AnyAsync(d => d.DepartmentId == custodian.DepartmentId))
                return BadRequest("Invalid DepartmentId");

            _context.Custodians.Add(custodian);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = custodian.CustodianId }, custodian);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Custodian custodian)
        {
            if (id != custodian.CustodianId) return BadRequest("ID mismatch");

            var existing = await _context.Custodians.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.Name = custodian.Name;
            existing.Designation = custodian.Designation;
            existing.DepartmentId = custodian.DepartmentId;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var custodion = await _context.Custodians.FindAsync(id);
            if (custodion == null) return NotFound();

            _context.Custodians.Remove(custodion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
