using DataAccess.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderWebsite.Pages
{
   public class ViewDetailsModel : PageModel
    {
        private readonly AppleProductManagerContext _context;

        public ViewDetailsModel(AppleProductManagerContext context)
        {
            _context = context;
        }
        public List<Product> Products { get; set; }
        public List<Cart> Carts { get; set; }
        public void OnGet()
        {
            Carts = _context.Carts.ToList();
            Products = _context.Products.ToList();
            string username = HttpContext.Session.GetString("username");
            foreach (var cart in Carts)
            {
                var updatedCartItems = _context.Carts.Where(p => p.Username == username).ToList();
                byte[] cartData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(updatedCartItems));
                HttpContext.Session.Set("Cart", cartData);
            }
        }
    }
}
