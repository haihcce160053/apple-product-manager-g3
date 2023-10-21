using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderWebsite.Pages
{
    public class VDAddModel : PageModel
    {
        private readonly AppleProductManagerContext _context;

        public List<Cart> CartsL { get; set; }
        public List<Product> Products { get; set; }
        public VDAddModel(AppleProductManagerContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Products = _context.Products.ToList();
            CartsL = _context.Carts.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string username = Request.Form["atcUsername"];
            string ca = Request.Form["cca"];
            int productId = int.Parse(Request.Form["atcProid"]);
            int quantity = int.Parse(Request.Form["atcQuantity2"]);
            decimal totalprice = decimal.Parse(Request.Form["atcTotalprice"]);
            string urlPage = Request.Form["url"];
            var existingCart = await _context.Carts.FirstOrDefaultAsync(c => c.Username == username && c.ProductId == productId);
            
            
            if (existingCart != null)
            {
                existingCart.Quantity += quantity;
                existingCart.Totalprice += totalprice;
            }
            else
            {
                var addCarts = new Cart
                {
                    Username = username,
                    ProductId = productId,
                    Quantity = quantity,
                    Totalprice = totalprice
                };
                _context.Carts.Add(addCarts);
            }
            if (CartsL != null)
            {
                foreach (var cart in CartsL)
                {
                    var updatedCartItems = _context.Carts.Where(p => p.Username == username).ToList();
                    byte[] cartData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(updatedCartItems));
                    HttpContext.Session.Set("Cart", cartData);
                }
            }
            TempData["VDadd"] = 1;
            await _context.SaveChangesAsync();
            return Redirect(urlPage+"");
        }
    }
}
