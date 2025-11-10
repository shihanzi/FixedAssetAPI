using FixedAssetAPI.Data;
using FixedAssetAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FixedAssetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAll()
        {
            // Include Department info (useful for display & linking)
            return await _context.Departments
                .Include(c => c.BuildingName)
                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetById(int id)
        {
            var department = await _context.Departments
                .Include(c => c.BuildingName)
                .FirstOrDefaultAsync(c => c.DepartmentId == id);

            if (department == null)
                return NotFound();

            return department;
        }

        [HttpPost]
        public async Task<ActionResult<Department>> Create(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = department.DepartmentId }, department);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Department department)
        {
            if (id != department.DepartmentId)
                return BadRequest("ID mismatch");

            var existing = await _context.Departments.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.DepartmentName = department.DepartmentName;
            existing.BuildingName = department.BuildingName;
            existing.Description = department.Description;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
                return NotFound();

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
