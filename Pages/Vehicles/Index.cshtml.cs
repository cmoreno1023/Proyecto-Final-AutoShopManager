using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoShopManager.Data;
using AutoShopManager.Models;

namespace AutoShopManager.Pages.Vehicles
{
    public class IndexModel : PageModel
    {
        private readonly AutoShopContext _context;

        public IndexModel(AutoShopContext context)
        {
            _context = context;
        }

        public IList<Vehicle> Vehicle { get; set; } = new List<Vehicle>();

        public async Task OnGetAsync()
        {
            if (_context.Vehicles != null)
            {
                Vehicle = await _context.Vehicles
                    .Include(v => v.Client)
                    .ToListAsync();
            }
        }
    }
}
