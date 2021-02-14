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
    public class IndexModel : PageModel
    {
        private readonly Cache.Data.ApplicationDbContext _context;

        public IndexModel(Cache.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public PaginatedList<Firearm> Firearms { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {

            int pageSize = 10;
            IQueryable<Firearm> firearms = from f in _context.Firearm
                .Include(f => f.CaliberGauge)
                select f;

            firearms = firearms.OrderByDescending(f => f.DateAcquired);

            Firearms = await PaginatedList<Firearm>.CreateAsync(
                firearms.AsNoTracking(), pageIndex ?? 1, pageSize);

        }
    }
}
