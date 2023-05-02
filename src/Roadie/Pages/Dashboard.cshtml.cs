using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Roadie.Pages
{
    [Authorize]
    [Route("dashboard")]
    public class DashboardModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
