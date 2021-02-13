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
    public class IndexModel : PageModel
    {
        private readonly Cache.Data.ApplicationDbContext _context;

        public IndexModel(Cache.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CaliberGauge> CaliberGauge { get;set; }

        public async Task OnGetAsync()
        {
            CaliberGauge = await _context.CaliberGauge.ToListAsync();
        }
    }
}
