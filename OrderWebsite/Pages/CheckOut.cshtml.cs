using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OrderWebsite.Pages
{
    public class CheckOutModel : PageModel
    {
        private readonly AppleProductManagerContext _context;

        public CheckOutModel(AppleProductManagerContext context)
        {
            _context = context;
        }
        public int ProductId { get; set; }

        public Cart addCarts { get; set; }
        public List<Cart> CartsL { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Products = _context.Products.ToList();
            DateTime currentDate = DateTime.Now;
            DateTime requiredDate = currentDate.AddDays(3);
            string username = HttpContext.Session.GetString("username");
            string urlPage = Request.Form["url"];
            string shipAdd = Request.Form["shipAdd"];
            var orderDateStr = currentDate.ToString("dd/MM/yyyy");
            var requiDateStr = requiredDate.ToString("dd/MM/yyyy");
            var orderDate = DateTime.ParseExact(orderDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var rDate = DateTime.ParseExact(requiDateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            byte[] cartData = HttpContext.Session.Get("Cart");
            string cartJson = Encoding.UTF8.GetString(cartData);
            List<Cart> cartItems = JsonConvert.DeserializeObject<List<Cart>>(cartJson);

            if (cartData != null)
            {
                    var addOrder = new Order
                    {
                        Username = username,
                        OrderDate = orderDate,
                        RequiredDate = rDate,
                        ShippedDate = rDate,
                        ShipAddress = shipAdd
                    };
                    _context.Orders.Add(addOrder);
            }
            foreach (var item in cartItems.Where(p => p.Username == username))
            {
                if (Products != null && item != null)
                {
                    var product = Products.FirstOrDefault(p => p.ProductId == item.ProductId);
                    if (product != null)
                    {
                        if(product.Quantity < item.Quantity)
                        {
                            TempData["ors"] = 2;
                            TempData["s"] = product.Quantity;
                            return Redirect(urlPage);
                        }
                        product.Quantity -= item.Quantity;
                    }
                }                    
                _context.Carts.Remove(item);
            }
            await _context.SaveChangesAsync();
            return Redirect(urlPage+"&ors=1");
        }
    }
}
