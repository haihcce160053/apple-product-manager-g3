using DataAccess.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace OrderWebsite.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppleProductManagerContext _context;

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public string Msg { get; set; }
        public LoginModel(AppleProductManagerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Account user { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                user = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == Username);                
                if (user != null && VerifyPassword(Password, user.Password) && user.Type == 3)
                {
                    HttpContext.Session.SetString("username", user.Username);
                    HttpContext.Session.SetInt32("role", 3);
                    return Redirect("/Index");
                }
            }
            Msg = "Invalid username or password";
            return Page();
        }
        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            return enteredPassword == storedPassword;
        }
    }
}
