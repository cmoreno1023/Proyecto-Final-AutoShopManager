using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoShopManager.Data;
using AutoShopManager.Models;

namespace AutoShopManager.Pages.Parts
{
    public class IndexModel : PageModel
    {
        private readonly AutoShopContext _context;

        public IndexModel(AutoShopContext context)
        {
            _context = context;
        }

        public IList<Part> Parts { get; set; } = new List<Part>();

        public async Task OnGetAsync()
        {
            if (_context.Parts != null)
            {
                Parts = await _context.Parts.ToListAsync();
            }
        }
    }
}
