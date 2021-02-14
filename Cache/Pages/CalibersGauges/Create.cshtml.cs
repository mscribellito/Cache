using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cache.Data;
using Cache.Models;

namespace Cache.Pages.CalibersGauges
{
    public class CreateModel : BasePageModel
    {

        public CreateModel(Cache.Data.ApplicationDbContext context)
            : base(context)
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

            Context.CaliberGauge.Add(CaliberGauge);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
