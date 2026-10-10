using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cache.Data;
using Cache.Models;

namespace Cache.Pages.CalibersGauges
{
    public class EditModel : PageModel
    {
        private readonly Cache.Data.CacheContext _context;

        public EditModel(Cache.Data.CacheContext context)
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
            if (calibergauge == null)
            {
                return NotFound();
            }
            CaliberGauge = calibergauge;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CaliberGauge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaliberGaugeExists(CaliberGauge.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CaliberGaugeExists(Guid id)
        {
            return _context.CaliberGauge.Any(e => e.Id == id);
        }
    }
}
