using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixedAssetAPI.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        public string BuildingName { get; set; } = string.Empty;
        [Required]
        public string RoomNumber { get; set;} = string.Empty;

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
