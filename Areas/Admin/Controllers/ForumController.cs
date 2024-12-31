using GestionCVForum.Data;
using GestionCVForum.Models.Domain;
using GestionCVForum.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestionCVForum.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ForumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForumController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var forums = await _context.Forums
                .Include(f => f.ForumCompanies)
                    .ThenInclude(fc => fc.Company)
                .ToListAsync();
            return View(forums);
        }

        public IActionResult Create()
        {
            ViewBag.Companies = new MultiSelectList(_context.Companies, "CompanyId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ForumViewModel model)
        {
            if (ModelState.IsValid)
            {
                var forum = new Forum
                {
                    Name = model.Name,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Location = model.Location,
                    CreatedAt = DateTime.Now
                };

                _context.Forums.Add(forum);
                await _context.SaveChangesAsync();

                if (model.SelectedCompanyIds != null)
                {
                    foreach (var companyId in model.SelectedCompanyIds)
                    {
                        _context.ForumCompanies.Add(new ForumCompany
                        {
                            ForumId = forum.ForumId,
                            CompanyId = companyId
                        });
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Companies = new MultiSelectList(_context.Companies, "CompanyId", "Name");
            return View(model);
        }
    }
}