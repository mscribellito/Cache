using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cache.Data;
using Cache.Models;

namespace Cache.Pages.CalibersGauges
{
    public class DeleteModel : BasePageModel
    {

        public DeleteModel(Cache.Data.ApplicationDbContext context)
            : base(context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CaliberGauge = await Context.CaliberGauge.FindAsync(id);

            if (CaliberGauge != null)
            {
                Context.CaliberGauge.Remove(CaliberGauge);
                await Context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
