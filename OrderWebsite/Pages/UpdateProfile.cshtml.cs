using DataAccess.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderWebsite.Pages
{
    public class UpdateProfileModel : PageModel
    {
        private readonly AppleProductManagerContext _context;

        public UpdateProfileModel(AppleProductManagerContext context)
        {
            _context = context;
        }

        public List<Cart> Carts { get; set; }
        public Account AccountO { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Login");
            }

            Carts = _context.Carts.ToList();

            var username = HttpContext.Session.GetString("username");
            AccountO = _context.Accounts.FirstOrDefault(c => c.Username == username);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Login");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var username = HttpContext.Session.GetString("username");
            AccountO = _context.Accounts.FirstOrDefault(c => c.Username == username);

            AccountO.Username = Request.Form["txtusername"];
            AccountO.Password = Request.Form["txtpassword"];
            AccountO.Fullname = Request.Form["txtFullname"];
            AccountO.Phone = Request.Form["txtphone"];
            AccountO.Email = Request.Form["txtEmail"];
            AccountO.Address = Request.Form["txtAddress"];

            _context.Accounts.Update(AccountO);
            _context.SaveChanges();

            TempData["success"] = 1;
            return Redirect("/UpdateProfile");
        }
    }
}
