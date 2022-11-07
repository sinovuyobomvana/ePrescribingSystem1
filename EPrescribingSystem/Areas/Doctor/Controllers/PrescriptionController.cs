using Microsoft.AspNetCore.Mvc;

namespace EPrescribingSystem.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class PrescriptionController : Controller
    {
        [Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
