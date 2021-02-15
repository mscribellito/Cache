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

namespace Cache.Pages.Firearms
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
        public Firearm Firearm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Firearm = await Context.Firearm
                .Include(f => f.CaliberGauge).FirstOrDefaultAsync(m => m.Id == id);

            if (Firearm == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Firearm,
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

            Firearm = await Context.Firearm.FindAsync(id);

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Firearm,
                Operations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            if (Firearm != null)
            {
                Context.Firearm.Remove(Firearm);
                await Context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
