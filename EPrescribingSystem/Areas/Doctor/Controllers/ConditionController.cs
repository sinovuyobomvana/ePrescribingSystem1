using EPrescribingSystem.Areas.Admin.Data.Services;
using EPrescribingSystem.Areas.Doctor.Data.Repository;
using EPrescribingSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EPrescribingSystem.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class ConditionController : Controller
    {
        private readonly IConditionRepository _service;
        private readonly EprescribingDBContext _context = null;

        public ConditionController(EprescribingDBContext context, IConditionRepository service)
        {
            _service = service;
            _context = context;
        }

        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
    }
}
