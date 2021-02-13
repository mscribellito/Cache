using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cache.Data;
using Cache.Models;

namespace Cache.Pages.Firearms
{
    public class CreateModel : PageModel
    {
        private readonly Cache.Data.ApplicationDbContext _context;

        public CreateModel(Cache.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CaliberGaugeId"] = new SelectList(_context.CaliberGauge, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Firearm Firearm { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Firearm.Add(Firearm);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
