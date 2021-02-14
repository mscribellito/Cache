using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cache.Data;
using Cache.Models;
using System.Linq.Dynamic.Core;

namespace Cache.Pages.Firearms
{
    public class IndexModel : BasePageModel
    {

        public IndexModel(Cache.Data.ApplicationDbContext context)
            : base(context)
        {
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; } 

        public const int PageSize = 10;

        public PaginatedList<Firearm> Firearms { get; set; }

        public async Task OnGetAsync()
        {

            IQueryable<Firearm> firearms = from f in Context.Firearm
                .Include(f => f.CaliberGauge)
                .OrderBy(SortBy)
                select f;

            Firearms = await PaginatedList<Firearm>.CreateAsync(
                firearms.AsNoTracking(), CurrentPage, PageSize);

        }
    }
}
