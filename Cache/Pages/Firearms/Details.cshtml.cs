using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cache.Data;
using Cache.Models;

namespace Cache.Pages.Firearms
{
    public class DetailsModel : PageModel
    {
        private readonly Cache.Data.CacheContext _context;

        public DetailsModel(Cache.Data.CacheContext context)
        {
            _context = context;
        }

        public Firearm Firearm { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firearm = await _context.Firearm
                .Include(f => f.CaliberGauge).FirstOrDefaultAsync(m => m.Id == id);

            if (firearm is not null)
            {
                Firearm = firearm;

                return Page();
            }

            return NotFound();
        }
    }
}
