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
        private readonly Cache.Data.ApplicationDbContext _context;

        public DetailsModel(Cache.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
