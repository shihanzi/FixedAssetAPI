using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixedAssetAPI.Models
{
    public class Valuation
    {
        [Key]
        public int ValuationId { get; set; }

        [ForeignKey("Asset")]
        public int AssetId { get; set; }

        public Asset? Asset { get; set; }

        public DateTime ValuationDate { get; set; } = DateTime.UtcNow;

        public decimal MarketValue { get; set; }

        public string? ValuatedBy { get; set; }
    }
}
