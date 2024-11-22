using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoShopManager.Data;
using AutoShopManager.Models;

namespace AutoShopManager.Pages.Parts
{
    public class EditModel : PageModel
    {
        private readonly AutoShopContext _context;

        public EditModel(AutoShopContext context)
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
            Part = part;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Part).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartExists(Part.IdPart))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PartExists(int id)
        {
            return (_context.Parts?.Any(e => e.IdPart == id)).GetValueOrDefault();
        }
    }
}


