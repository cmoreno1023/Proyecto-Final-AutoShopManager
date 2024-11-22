// Edit.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoShopManager.Data;
using AutoShopManager.Models;

namespace AutoShopManager.Pages.Appointments
{
    public class EditModel : PageModel
    {
        private readonly AutoShopContext _context;

        public EditModel(AutoShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FirstOrDefaultAsync(m => m.IdAppointment == id);
            if (appointment == null)
            {
                return NotFound();
            }
            Appointment = appointment;
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "FirstName");
            ViewData["IdVehicle"] = new SelectList(_context.Vehicles
                .Select(v => new
                {
                    v.IdVehicle,
                    Description = $"{v.Brand} {v.Model} - {v.LicensePlate}"
                }), "IdVehicle", "Description");
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

            _context.Attach(Appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(Appointment.IdAppointment))
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

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.IdAppointment == id);
        }
    }
}
