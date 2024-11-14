using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoShopManager.Data;
using AutoShopManager.Models;

namespace AutoShopManager.Pages.Repairs
{
    public class IndexModel : PageModel
    {
        private readonly AutoShopContext _context;

        public IndexModel(AutoShopContext context)
        {
            _context = context;
        }

        public IList<Repair> Repairs { get; set; } = new List<Repair>();

        public async Task OnGetAsync()
        {
            if (_context.Repairs != null)
            {
                Repairs = await _context.Repairs
                    .Include(r => r.Vehicle)
                    .ToListAsync();
            }
        }
    }
}
