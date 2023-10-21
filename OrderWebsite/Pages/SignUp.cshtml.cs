using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderWebsite.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly AppleProductManagerContext _context;

        public SignUpModel(AppleProductManagerContext context)
        {
            _context = context;
        }
        public string Msg { get; set; }

        [BindProperty]
        public Account user { get; set; }
        public List<Account> checkUser { get; set; }
        public IActionResult OnGet()
        {
            checkUser = _context.Accounts.ToList();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var checkU = await _context.Accounts.FirstOrDefaultAsync(p => p.Username == user.Username || p.Email == user.Email);
            if (!ModelState.IsValid || checkU != null)
            {
                return Redirect("/SignUp?err=1");
            }
            else
            {
                _context.Accounts.Add(user);
                await _context.SaveChangesAsync();
            }

            return Redirect("/SignUp?success=1");
        }
    }
}
