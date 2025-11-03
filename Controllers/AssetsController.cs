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
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAssets), new { id = asset.AssetId }, asset);
        }
    }
}
