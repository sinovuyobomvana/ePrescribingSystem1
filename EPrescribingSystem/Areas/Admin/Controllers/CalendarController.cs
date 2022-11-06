using Microsoft.AspNetCore.Mvc;

namespace EPrescribingSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CalendarController : Controller
    {
        [Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
