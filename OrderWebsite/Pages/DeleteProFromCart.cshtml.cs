using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace OrderWebsite.Pages
{
    public class DeleteProFromCartModel : PageModel
    {
        private readonly AppleProductManagerContext _context;

        public DeleteProFromCartModel(AppleProductManagerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public int ProductId { get; set; }
        [BindProperty]
        public string userI { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int pid, string user)
        {
            ProductId = pid;
            userI = user;
            var pro = await _context.Carts.FirstOrDefaultAsync(p => p.ProductId == ProductId);
            if (pro != null)
            {
                _context.Carts.Remove(pro);
                await _context.SaveChangesAsync();
            }

            return Redirect("/Carts?uid=" + userI.ToString());
        }
    }
}
