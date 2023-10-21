using DataAccess.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppleProductManagerContext _context;

        private readonly ILogger<IndexModel> _logger;

        public List<Cart> Carts { get; set; }
        public IndexModel(ILogger<IndexModel> logger, AppleProductManagerContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            string username = HttpContext.Session.GetString("username");
            Carts = _context.Carts.ToList();
            foreach(var cart in Carts)
            {
                var updatedCartItems = _context.Carts.Where(p => p.Username == username).ToList();
                byte[] cartData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(updatedCartItems));
                HttpContext.Session.Set("Cart", cartData);
            }
        }
    }
}
