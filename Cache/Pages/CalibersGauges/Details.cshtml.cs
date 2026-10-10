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
    public class DetailsModel : PageModel
    {
        private readonly Cache.Data.CacheContext _context;

        public DetailsModel(Cache.Data.CacheContext context)
        {
            _context = context;
        }

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
    }
}
