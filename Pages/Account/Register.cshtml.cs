using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoShopManager.Data;
using AutoShopManager.Models;

namespace AutoShopManager.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly AutoShopContext _context;

        public RegisterModel(AutoShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Verificar si el email ya existe
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Email already registered.");
                return Page();
            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Login");
        }
    }
}
