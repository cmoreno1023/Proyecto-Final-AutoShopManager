using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoShopManager.Data;
using AutoShopManager.Models;

namespace AutoShopManager.Pages.Parts
{
    public class DeleteModel : PageModel
    {
        private readonly AutoShopContext _context;

        public DeleteModel(AutoShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Part Part { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Parts == null)
            {
                return NotFound();
            }

            var part = await _context.Parts.FirstOrDefaultAsync(m => m.IdPart == id);

            if (part == null)
            {
                return NotFound();
            }
            else
            {
                Part = part;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Parts == null)
            {
                return NotFound();
            }

            var part = await _context.Parts.FindAsync(id);

            if (part != null)
            {
                Part = part;
                _context.Parts.Remove(Part);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
