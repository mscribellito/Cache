using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Cache.Data;

namespace Cache.Pages
{

    public class BasePageModel : PageModel
    {

        protected ApplicationDbContext Context { get; }

        public BasePageModel(
            ApplicationDbContext context) : base()
        {
            Context = context;
        }

    }

}