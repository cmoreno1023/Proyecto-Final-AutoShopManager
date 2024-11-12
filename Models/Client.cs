using System.ComponentModel.DataAnnotations;

namespace AutoShopManager.Models
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }

        [Required]
        public string FirstName { get; set; } = default!;

        [Required]
        public string LastName { get; set; } = default!;

        [Required]
        public string Phone { get; set; } = default!;

        [Required]
        public string Email { get; set; } = default!;

        public string? Address { get; set; }
    }
}
s