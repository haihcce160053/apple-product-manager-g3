using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OrderWebsite.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGetAsync()
        {
            HttpContext.Session.Clear();
            return Redirect("/Index");
        }
    }
}
