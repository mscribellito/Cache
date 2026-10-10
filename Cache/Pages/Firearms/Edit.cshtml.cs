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

namespace Cache.Pages.Firearms
{
    public class EditModel : PageModel
    {
        private readonly Cache.Data.CacheContext _context;

        public EditModel(Cache.Data.CacheContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Firearm Firearm { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firearm = await _context.Firearm.FirstOrDefaultAsync(m => m.Id == id);
            if (firearm == null)
            {
                return NotFound();
            }
            Firearm = firearm;
            ViewData["CaliberGaugeId"] = new SelectList(_context.Set<CaliberGauge>(), "Id", "Name");
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

            _context.Attach(Firearm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirearmExists(Firearm.Id))
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

        private bool FirearmExists(Guid id)
        {
            return _context.Firearm.Any(e => e.Id == id);
        }
    }
}
