using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixedAssetAPI.Models
{
    public class Custodian
    {
        [Key]
        public int CustodianId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Designation { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
