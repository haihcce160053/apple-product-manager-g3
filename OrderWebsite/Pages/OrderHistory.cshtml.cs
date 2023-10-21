using DataAccess.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace OrderWebsite.Pages
{
    public class OrderHistoryModel : PageModel
    {
        private readonly AppleProductManagerContext _context;

        public OrderHistoryModel(AppleProductManagerContext context)
        {
            _context = context;
        }
        public List<Cart> Carts { get; set; }
        public List<Order> Orders { get; set; }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Login");
            }
            Orders = _context.Orders.ToList();
            Carts = _context.Carts.ToList();
            return Page();
        }
    }
}
