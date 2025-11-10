using FixedAssetAPI.Data;
using FixedAssetAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FixedAssetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AssetsController(AppDbContext context)
        {
            _context  = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAssets()
        {
            return await _context.Assets
                .Include(a => a.Category)
                .Include(a => a.Location)
                .Include(a => a.Custodian)
                .Include(a => a.Department)
                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Asset>> GetAsset(int id)
        {
            var asset = await _context.Assets
                .Include(a => a.Category)
                .Include(a => a.Location)
                .Include(a => a.Custodian)
                .Include(a => a.Department)
                .FirstOrDefaultAsync(a => a.AssetId == id);

            if (asset == null)
                return NotFound();

            return asset;
        }

        private decimal CalculateDepreciatedValue(Asset asset, double rate)
        {
            var years = (DateTime.Now - asset.AcquisitionDate).Days / 365.0;
            var depreciatedValue = asset.AcquisitionCost * (decimal)Math.Pow((double)(1 - rate / 100), years);
            return Math.Round(depreciatedValue, 2);
        }

        [HttpPost]
        public async Task<ActionResult<Asset>> CreateAsset(Asset asset)
        {
            // --- Validate required fields
            if (asset.CategoryId == 0)
                return BadRequest("CategoryId is required.");

            if (asset.AcquisitionCost <= 0)
                return BadRequest("Cost of acquisition must be greater than zero.");

            if (asset.AcquisitionDate == default)
                asset.AcquisitionDate = DateTime.Now;

            // --- Fetch Depreciation Rate
            var depRate = await _context.DepreciationRates
                .FirstOrDefaultAsync(r => r.CategoryId == asset.CategoryId);

            if (depRate == null)
                return BadRequest("No depreciation rate found for this category.");

            // --- Calculate Depreciation
            asset.BookValue = asset.AcquisitionCost;
            asset.CurrentDepreciatedValue = CalculateDepreciatedValue(asset, depRate.Rate);

            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAsset), new { id = asset.AssetId }, asset);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsset(int id, Asset asset)
        {
            if (id != asset.AssetId)
                return BadRequest("ID mismatch");

            var existingAsset = await _context.Assets.FindAsync(id);
            if (existingAsset == null)
                return NotFound();

            // Update fields
            existingAsset.Description = asset.Description;
            existingAsset.CategoryId = asset.CategoryId;
            existingAsset.LocationId = asset.LocationId;
            existingAsset.DepartmentId = asset.DepartmentId;
            existingAsset.CustodianId = asset.CustodianId;
            existingAsset.AcquisitionCost = asset.AcquisitionCost;
            existingAsset.AcquisitionDate = asset.AcquisitionDate;
            existingAsset.LabelTag = asset.LabelTag;
            existingAsset.Condition = asset.Condition;

            // Recalculate Depreciation
            var depRate = await _context.DepreciationRates
                .FirstOrDefaultAsync(r => r.CategoryId == asset.CategoryId);

            if (depRate != null)
                existingAsset.CurrentDepreciatedValue = CalculateDepreciatedValue(existingAsset, depRate.Rate);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
                return NotFound();

            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
