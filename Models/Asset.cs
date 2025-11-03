using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FixedAssetAPI.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }

        [Required]
        public string AssetCode { get; set; } = string.Empty;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public string Description { get; set; } = string.Empty;

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public Location? Location { get; set; }

        [ForeignKey("Custodian")]
        public int CustodianId { get; set; }

        public Custodian? Custodian { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public decimal AcquisitionCost { get; set; }

        public decimal BookValue { get; set; }

        public decimal? MarketValue { get; set; }

        public string Condition { get; set; } = "Good";

        public string LabelTag { get; set; } = string.Empty;

        public string Status { get; set; } = "Active";
    }
}
