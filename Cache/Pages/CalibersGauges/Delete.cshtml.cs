using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cache.Data;
using Cache.Models;

namespace Cache.Pages.CalibersGauges
{
    public class DeleteModel : PageModel
    {
        private readonly Cache.Data.CacheContext _context;

        public DeleteModel(Cache.Data.CacheContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CaliberGauge CaliberGauge { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calibergauge = await _context.CaliberGauge.FirstOrDefaultAsync(m => m.Id == id);

            if (calibergauge is not null)
            {
                CaliberGauge = calibergauge;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calibergauge = await _context.CaliberGauge.FindAsync(id);
            if (calibergauge != null)
            {
                CaliberGauge = calibergauge;
                _context.CaliberGauge.Remove(CaliberGauge);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
