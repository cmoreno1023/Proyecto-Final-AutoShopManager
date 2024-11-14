using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoShopManager.Data;
using AutoShopManager.Models;

namespace AutoShopManager.Pages.Repairs
{
    public class EditModel : PageModel
    {
        private readonly AutoShopContext _context;

        public EditModel(AutoShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Repair Repair { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Repairs == null)
            {
                return NotFound();
            }

            var repair = await _context.Repairs.FirstOrDefaultAsync(m => m.IdRepair == id);
            if (repair == null)
            {
                return NotFound();
            }
            Repair = repair;

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
                ViewData["IdVehicle"] = new SelectList(_context.Vehicles
                    .Select(v => new
                    {
                        v.IdVehicle,
                        Description = $"{v.Brand} {v.Model} - {v.LicensePlate}"
                    }), "IdVehicle", "Description");
                return Page();
            }

            _context.Attach(Repair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairExists(Repair.IdRepair))
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

        private bool RepairExists(int id)
        {
            return (_context.Repairs?.Any(e => e.IdRepair == id)).GetValueOrDefault();
        }
    }
}
