using System.ComponentModel.DataAnnotations;

namespace AutoShopManager.Models
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }  // Asegúrate que sea IdClient y no Id

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = default!;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = default!;

        [Required]
        [StringLength(15)]
        public string Phone { get; set; } = default!;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = default!;

        [StringLength(200)]
        public string? Address { get; set; }
    }
}