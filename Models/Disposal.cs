using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixedAssetAPI.Models
{
    public class Disposal
    {
        [Key]
        public int DisposalId { get; set; }

        [ForeignKey("Asset")]
        public int AssetId { get; set; }
        public Asset? Asset { get; set; }
        [Required]
        public string Reason { get; set; }=string.Empty;
        [Required]
        public string DisposalMethod { get; set; } = "Auction";

        public DateTime ApprovalDate { get; set; }=DateTime.UtcNow;
        public string? ApprovedBy { get; set; }
        public string? Remarks { get; set; }

    }
}
