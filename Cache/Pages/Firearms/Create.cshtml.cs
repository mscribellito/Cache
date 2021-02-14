using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cache.Data;
using Cache.Models;

namespace Cache.Pages.Firearms
{
    public class CreateModel : BasePageModel
    {

        public CreateModel(Cache.Data.ApplicationDbContext context)
            : base(context)
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

            Context.Firearm.Add(Firearm);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
