using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoShopManager.Data;
using AutoShopManager.Models;

namespace AutoShopManager.Pages.Repairs
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
            // Cargar lista de vehículos para el dropdown
            ViewData["IdVehicle"] = new SelectList(_context.Vehicles
                .Select(v => new
                {
                    v.IdVehicle,
                    Description = $"{v.Brand} {v.Model} - {v.LicensePlate}"
                }), "IdVehicle", "Description");

            // Establecer fechas por defecto
            Repair = new Repair
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1)
            };

            return Page();
        }

        [BindProperty]
        public Repair Repair { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["IdVehicle"] = new SelectList(_context.Vehicles
                    .Select(v => new
                    {
                        v.IdVehicle,
                        Description = $"{v.Brand} {v.Model} - {v.LicensePlate}"
                    }), "IdVehicle", "Description");
                return Page();
            }

            _context.Repairs.Add(Repair);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}