using DataAccess.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderWebsite.Pages
{
    public class CartsModel : PageModel
    {
        private readonly AppleProductManagerContext _context;

        public CartsModel(AppleProductManagerContext context)
        {
            _context = context;
        }
        public int ProductId { get; set; }
        public Cart addCarts { get; set; }
        public List<Cart> CartsL { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductType> Type { get; set; }
        public List<Order> Orders { get; set; }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Login");
            }
            Products = _context.Products.ToList();
            CartsL = _context.Carts.ToList();
            Type = _context.ProductTypes.ToList();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Login");
            }
            CartsL = _context.Carts.ToList();
            string username = Request.Form["atcUsername"];
            string ca = Request.Form["cca"];
            int productId = int.Parse(Request.Form["atcProid"]);
            int quantity = int.Parse(Request.Form["atcQuantity"]);
            decimal totalprice = decimal.Parse(Request.Form["atcTotalprice"]);
            string urlPage = Request.Form["url"];
            string urlPlus= Request.Form["urlPlus"];
            string urlMi = Request.Form["urlMinus"];
            var existingCart = await _context.Carts.FirstOrDefaultAsync(c => c.Username == username && c.ProductId == productId);
            var orderDateStr = DateTime.Now.ToString("dd/MM/yyyy");
            var orderDate = DateTime.ParseExact(orderDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (existingCart != null && urlMi != null)
            {
                if(existingCart.Quantity > 1)
                {
                    existingCart.Quantity -= 1;
                    existingCart.Totalprice -= totalprice;
                }
            }
            else if (existingCart != null)
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

            await _context.SaveChangesAsync();
            if (urlPlus != null)
            {
                return Redirect(urlPlus + "");
            }
            if(urlMi != null)
            {
                return Redirect(urlMi + "");
            }
            if (urlPage.Contains("/View"))
            {
                TempData["Vadd"] = 1;
                return Redirect(urlPage + "");
            }
            if (urlPage.Contains("/Search"))
            {
                TempData["Sadd"] = 1;
                return Redirect(urlPage + "");
            }
            TempData["Cadd"] = 1;
            return Redirect(urlPage + "");
        }
    }
}
