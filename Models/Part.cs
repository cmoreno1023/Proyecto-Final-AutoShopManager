using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoShopManager.Models
{
    public class Part
    {
        [Key]
        public int IdPart { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Part Number is required")]
        [Display(Name = "Part Number")]
        [StringLength(50)]
        public string PartNumber { get; set; } = default!;

        [Required(ErrorMessage = "Price is required")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Provider is required")]
        [StringLength(100)]
        public string Provider { get; set; } = default!;
    }
}
