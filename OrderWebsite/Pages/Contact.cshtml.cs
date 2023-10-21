using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace OrderWebsite.Pages
{
    public class ContactModel : PageModel
    {
        private readonly AppleProductManagerContext _context;

        public ContactModel(AppleProductManagerContext context)
        {
            _context = context;
        }
        public List<Cart> Carts { get; set; }
        public void OnGet()
        {
            Carts = _context.Carts.ToList();
        }
    }
}
