using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoShopManager.Models
{
    public class Repair
    {
        [Key]
        public int IdRepair { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500)]
        public string Description { get; set; } = default!;

        [Required(ErrorMessage = "Vehicle is required")]
        public int IdVehicle { get; set; }

        [ForeignKey("IdVehicle")]
        public virtual Vehicle? Vehicle { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Estimated Cost is required")]
        [Display(Name = "Estimated Cost")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal EstimatedCost { get; set; }
    }
}
