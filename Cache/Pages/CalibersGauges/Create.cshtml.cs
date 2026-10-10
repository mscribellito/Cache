using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cache.Data;
using Cache.Models;

namespace Cache.Pages.CalibersGauges
{
    public class CreateModel : PageModel
    {
        private readonly Cache.Data.CacheContext _context;

        public CreateModel(Cache.Data.CacheContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CaliberGauge CaliberGauge { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CaliberGauge.Add(CaliberGauge);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
