using Microsoft.AspNetCore.Mvc;
using GestionCVForum.Data;

namespace GestionCVForum.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var forums = _context.Forums.ToList();
            return View(forums);
        }
    }
}
