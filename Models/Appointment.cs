using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoShopManager.Models
{
    public class Appointment
    {
        [Key]
        public int IdAppointment { get; set; }

        [Required]
        public int IdVehicle { get; set; }

        [ForeignKey("IdVehicle")]
        [DeleteBehavior(DeleteBehavior.NoAction)]  // Agregamos esto
        public virtual Vehicle? Vehicle { get; set; }

        [Required]
        public int IdClient { get; set; }

        [ForeignKey("IdClient")]
        [DeleteBehavior(DeleteBehavior.NoAction)]  // Y esto
        public virtual Client? Client { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Required]
        [Display(Name = "Service Description")]
        [StringLength(500)]
        public string ServiceDescription { get; set; } = default!;
    }
}
