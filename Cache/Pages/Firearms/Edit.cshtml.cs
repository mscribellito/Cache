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
        private readonly Cache.Data.ApplicationDbContext _context;

        public EditModel(Cache.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Firearm Firearm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Firearm = await _context.Firearm
                .Include(f => f.CaliberGauge).FirstOrDefaultAsync(m => m.Id == id);

            if (Firearm == null)
            {
                return NotFound();
            }
           ViewData["CaliberGaugeId"] = new SelectList(_context.CaliberGauge, "Id", "Name");
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

        private bool FirearmExists(int id)
        {
            return _context.Firearm.Any(e => e.Id == id);
        }
    }
}
