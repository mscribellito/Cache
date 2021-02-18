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

namespace Cache.Pages.Firearms
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

        public PaginatedList<Firearm> Firearms { get; set; }

        public async Task OnGetAsync()
        {
            
            var currentUserId = UserManager.GetUserId(User);

            IQueryable<Firearm> firearms = from f in Context.Firearm
                .Include(f => f.CaliberGauge)
                .Where(f => f.UserId == currentUserId)
                .OrderBy(SortBy + " descending")
                select f;

            Firearms = await PaginatedList<Firearm>.CreateAsync(
                firearms.AsNoTracking(), CurrentPage, PageSize);

        }
    }
}
