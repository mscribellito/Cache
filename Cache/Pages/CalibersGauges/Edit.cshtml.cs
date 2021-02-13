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
        private readonly Cache.Data.ApplicationDbContext _context;

        public EditModel(Cache.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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

        private bool CaliberGaugeExists(int id)
        {
            return _context.CaliberGauge.Any(e => e.Id == id);
        }
    }
}
