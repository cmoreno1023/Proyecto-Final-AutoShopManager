using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoShopManager.Data;
using AutoShopManager.Models;

namespace AutoShopManager.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly AutoShopContext _context;

        public IndexModel(AutoShopContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get; set; } = new List<Appointment>();

        public async Task OnGetAsync()
        {
            if (_context.Appointments != null)
            {
                Appointment = await _context.Appointments
                    .Include(a => a.Vehicle)
                    .Include(a => a.Client)
                    .ToListAsync();
            }
        }
    }
}
