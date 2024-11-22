// Create.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoShopManager.Data;
using AutoShopManager.Models;

namespace AutoShopManager.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly AutoShopContext _context;

        public CreateModel(AutoShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "FirstName");
            ViewData["IdVehicle"] = new SelectList(_context.Vehicles
                .Select(v => new
                {
                    v.IdVehicle,
                    Description = $"{v.Brand} {v.Model} - {v.LicensePlate}"
                }), "IdVehicle", "Description");

            Appointment = new Appointment
            {
                Date = DateTime.Today,
                Time = DateTime.Now
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "FirstName");
                ViewData["IdVehicle"] = new SelectList(_context.Vehicles
                    .Select(v => new
                    {
                        v.IdVehicle,
                        Description = $"{v.Brand} {v.Model} - {v.LicensePlate}"
                    }), "IdVehicle", "Description");
                return Page();
            }

            _context.Appointments.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
