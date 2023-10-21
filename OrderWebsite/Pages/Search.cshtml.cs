using DataAccess.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderWebsite.Pages
{
    public class SearchModel : PageModel
    {
        private readonly AppleProductManagerContext _context;

        public SearchModel(AppleProductManagerContext context)
        {
            _context = context;
        }
        public List<ProductType> Category { get; set; }
        public List<Product> Products { get; set; }
        public List<Cart> Carts { get; set; }
        public void OnGet()
        {
            Carts = _context.Carts.ToList();
            Products = _context.Products.ToList();      
            Category = _context.ProductTypes.ToList();
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
