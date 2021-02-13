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
        private readonly Cache.Data.ApplicationDbContext _context;

        public DeleteModel(Cache.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CaliberGauge CaliberGauge { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CaliberGauge = await _context.CaliberGauge.FirstOrDefaultAsync(m => m.Id == id);

            if (CaliberGauge == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CaliberGauge = await _context.CaliberGauge.FindAsync(id);

            if (CaliberGauge != null)
            {
                _context.CaliberGauge.Remove(CaliberGauge);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
