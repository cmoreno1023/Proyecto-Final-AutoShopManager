using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoShopManager.Models
{
    public class Repair
    {
        [Key]
        public int IdRepair { get; set; }

        [Required]
        public string Description { get; set; } = default!;

        [Required]
        public int IdVehicle { get; set; }

        [ForeignKey("IdVehicle")]
        public virtual Vehicle? Vehicle { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Estimated Cost")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal EstimatedCost { get; set; }
    }
}