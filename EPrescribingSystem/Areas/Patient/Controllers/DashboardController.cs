using Microsoft.AspNetCore.Mvc;

namespace EPrescribingSystem.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class DashboardController : Controller
    {
        [Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
