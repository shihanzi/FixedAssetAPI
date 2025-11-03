using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FixedAssetAPI.Models
{
    public class DepreciationRate
    {
        [Key]
        public int DepreciationRateId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [Range(0, 100)]
        public double Rate { get; set; }
    }
}
