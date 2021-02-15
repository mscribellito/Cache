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

namespace Cache.Pages.Firearms
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
            ViewData["CaliberGaugeId"] = new SelectList(Context.CaliberGauge, "Id", "Name");
                return Page();
        }

        [BindProperty]
        public Firearm Firearm { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Firearm.UserId = UserManager.GetUserId(User);

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Firearm,
                Operations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.Firearm.Add(Firearm);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
