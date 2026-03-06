using Microsoft.AspNetCore.Mvc;

namespace VistraTest.Controllers
{
    public class DynamicControlsController : Controller
    {
        // GET: /DynamicControls/Index
        public IActionResult Index()
        {
            return View();
        }
    }
}
