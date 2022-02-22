using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibApp.Controllers
{
    public class RentalsController : Controller
    {
        [Authorize(Policy = "RequireManagerRole")]
        public IActionResult New()
        {
            return View();
        }
    }
}
