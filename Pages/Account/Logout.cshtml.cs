using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoShopManager.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            // Cerrar la sesión eliminando la cookie
            await HttpContext.SignOutAsync("MyCookieAuth");

            // Redirigir al inicio
            return RedirectToPage("/Index");
        }
    }
}