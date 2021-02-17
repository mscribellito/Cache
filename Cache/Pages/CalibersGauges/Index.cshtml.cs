using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cache.Data;
using Cache.Models;
using System.Linq.Dynamic.Core;

namespace Cache.Pages.CalibersGauges
{
    public class IndexModel : BasePageModel
    {

        public IndexModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; } 

        public const int PageSize = 10;

        public PaginatedList<CaliberGauge> CalibersGauges { get; set; }

        public async Task OnGetAsync()
        {
            
            var currentUserId = UserManager.GetUserId(User);

            IQueryable<CaliberGauge> calibersGauges = from cg in Context.CaliberGauge
                .Where(cg => cg.UserId == currentUserId)
                .OrderBy(SortBy)
                select cg;

            CalibersGauges = await PaginatedList<CaliberGauge>.CreateAsync(
                calibersGauges.AsNoTracking(), CurrentPage, PageSize);

        }
    }
}
