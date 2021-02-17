using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cache.Authorization;
using Cache.Data;
using Cache.Models;

namespace Cache.Pages.CalibersGauges
{
    public class CreateModel : BasePageModel
    {

        public CreateModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CaliberGauge CaliberGauge { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CaliberGauge.UserId = UserManager.GetUserId(User);

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, CaliberGauge,
                Operations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.CaliberGauge.Add(CaliberGauge);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
