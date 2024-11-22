// Create.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoShopManager.Data;
using AutoShopManager.Models;

namespace AutoShopManager.Pages.Parts
{
    public class CreateModel : PageModel
    {
        private readonly AutoShopContext _context;

        public CreateModel(AutoShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Part Part { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Parts.Add(Part);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
