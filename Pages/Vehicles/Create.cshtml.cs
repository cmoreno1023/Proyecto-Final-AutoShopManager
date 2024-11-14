using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoShopManager.Data;
using AutoShopManager.Models;

namespace AutoShopManager.Pages.Vehicles
{
    public class CreateModel : PageModel
    {
        private readonly AutoShopContext _context;

        public CreateModel(AutoShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Cargar el SelectList de clientes para el dropdown
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient",
                "FirstName"); // Puedes personalizar qué se muestra
            return Page();
        }

        [BindProperty]
        public Vehicle Vehicle { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient",
                    "FirstName");
                return Page();
            }

            _context.Vehicles.Add(Vehicle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}