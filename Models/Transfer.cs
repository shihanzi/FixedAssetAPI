using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixedAssetAPI.Models
{
    public class Transfer
    {
        [Key]
        public int TransferId { get; set; }
        [ForeignKey("Asset")]
        public int AssetId { get; set; }
        public Asset? Asset { get; set; }

        public int FromLocationId { get; set; }
        public int ToLocaiotnId { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovalDate { get; set; }

        public string? ApprovedBy { get; set; }
        public string? Remarks { get; set; }
    }
}
