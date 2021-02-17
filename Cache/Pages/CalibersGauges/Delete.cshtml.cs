using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cache.Authorization;
using Cache.Data;
using Cache.Models;

namespace Cache.Pages.CalibersGauges
{
    public class DeleteModel : BasePageModel
    {

        public DeleteModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public CaliberGauge CaliberGauge { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CaliberGauge = await Context.CaliberGauge.FirstOrDefaultAsync(m => m.Id == id);

            if (CaliberGauge == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, CaliberGauge,
                Operations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CaliberGauge = await Context.CaliberGauge.FindAsync(id);

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, CaliberGauge,
                Operations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            if (CaliberGauge != null)
            {
                Context.CaliberGauge.Remove(CaliberGauge);
                await Context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
