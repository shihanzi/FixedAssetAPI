using FixedAssetAPI.Data;
using FixedAssetAPI.Models;
using Microsoft.AspNetCore.Http;
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
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Asset>> CreateAsset(Asset asset)
        {
            // Calculate depreciation (straight-line)
            var rate = await _context.DepreciationRates
                .FirstOrDefaultAsync(r => r.CategoryId == asset.CategoryId);

            if (rate != null)
            {
                var years = DateTime.Now.Year - asset.AcquisitionDate.Year;
                if (years < 0) years = 0;
                var depreciation = (double)asset.AcquisitionCost * (rate.Rate / 100) * years;
                asset.BookValue = asset.AcquisitionCost - (decimal)depreciation;
                if (asset.BookValue < 0) asset.BookValue = 0;
            }
            else
            {
                // If no depreciation rate set
                asset.BookValue = asset.AcquisitionCost;
            }

            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAssets), new { id = asset.AssetId }, asset);
        }
    }
}
