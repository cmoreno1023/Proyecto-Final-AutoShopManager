using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoShopManager.Models
{
    public class Vehicle
    {
        [Key]
        public int IdVehicle { get; set; }

        [Required(ErrorMessage = "License Plate is required")]
        [Display(Name = "License Plate")]
        [StringLength(10)]
        public string LicensePlate { get; set; } = default!;

        [Required(ErrorMessage = "Brand is required")]
        [StringLength(50)]
        public string Brand { get; set; } = default!;

        [Required(ErrorMessage = "Model is required")]
        [StringLength(50)]
        public string Model { get; set; } = default!;

        [Required(ErrorMessage = "Year is required")]
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Color is required")]
        [StringLength(30)]
        public string Color { get; set; } = default!;

        [Required(ErrorMessage = "Client is required")]
        [Display(Name = "Client")]
        public int IdClient { get; set; }

        [ForeignKey("IdClient")]
        public virtual Client? Client { get; set; }
    }
}
