using Microsoft.AspNetCore.Mvc;

namespace GestionCVForum.Controllers
{
    public class RecruiterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
