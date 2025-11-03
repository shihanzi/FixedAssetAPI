using System.ComponentModel.DataAnnotations;

namespace FixedAssetAPI.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; } = string.Empty;

        public string Description { get; set; }
        public string? BuildingName { get; set; }
    }
}
