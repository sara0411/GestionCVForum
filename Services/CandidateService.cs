using GestionCVForum.Models.Domain;
using GestionCVForum.Models.ViewModels;
using GestionCVForum.Data;
using Microsoft.EntityFrameworkCore;
namespace GestionCVForum.Services
{
    // Services/ICandidateService.cs
    public interface ICandidateService
    {
        Task<int> SubmitApplication(CandidateSubmissionViewModel model);
        Task<bool> SaveCV(IFormFile file, string fileName);  // Returns Task<bool>
    }

    // Services/CandidateService.cs
    public class CandidateService : ICandidateService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CandidateService(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<bool> SaveCV(IFormFile file, string fileName)  // Changed return type to Task<bool>
        {
            try
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return true;  // Return true if successful
            }
            catch (Exception)
            {
                return false;  // Return false if there was an error
            }
        }

        public async Task<int> SubmitApplication(CandidateSubmissionViewModel model)
        {
            var fileName = $"{Guid.NewGuid()}_{model.CV.FileName}";
            var cvSaved = await SaveCV(model.CV, fileName);

            if (!cvSaved)
            {
                throw new Exception("Failed to save CV file");
            }

            var candidate = new Candidate
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Skills = model.Skills,
                CVPath = fileName,
                CreatedAt = DateTime.Now
            };

            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            foreach (var companyId in model.SelectedCompanyIds)
            {
                var forum = await _context.ForumCompanies
                    .Where(fc => fc.CompanyId == companyId)
                    .OrderByDescending(fc => fc.Forum.StartDate)
                    .Select(fc => fc.Forum)
                    .FirstOrDefaultAsync();

                if (forum != null)
                {
                    _context.CandidateCompanies.Add(new CandidateCompany
                    {
                        CandidateId = candidate.CandidateId,
                        CompanyId = companyId,
                        ForumId = forum.ForumId,
                        ApplicationDate = DateTime.Now
                    });
                }
            }

            await _context.SaveChangesAsync();
            return candidate.CandidateId;
        }
    }

}
