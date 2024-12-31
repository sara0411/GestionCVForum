using Microsoft.AspNetCore.Mvc;
using GestionCVForum.Models.ViewModels;
using GestionCVForum.Services;
using GestionCVForum.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionCVForum.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidateService _candidateService;
        private readonly ApplicationDbContext _context;

        public CandidateController(ICandidateService candidateService, ApplicationDbContext context)
        {
            _candidateService = candidateService;
            _context = context;
        }

        public IActionResult Submit()
        {
            ViewBag.Companies = new SelectList(_context.Companies, "CompanyId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(CandidateSubmissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _candidateService.SubmitApplication(model);
                    return RedirectToAction("Success");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error submitting application.");
                }
            }
            ViewBag.Companies = new SelectList(_context.Companies, "CompanyId", "Name");
            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
