using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoShopManager.Data;
using AutoShopManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace AutoShopManager.Pages.Clients
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly AutoShopContext _context;

        public IndexModel(AutoShopContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get; set; } = new List<Client>();

        public async Task OnGetAsync()
        {
            if (_context.Clients != null)
            {
                Client = await _context.Clients.ToListAsync();
            }
        }
    }
}
