using System.ComponentModel.DataAnnotations;

namespace GestionCVForum.Models.Domain;

public class Company
{
    public int CompanyId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Industry { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual ICollection<ForumCompany> ForumCompanies { get; set; }
    public virtual ICollection<Recruiter> Recruiters { get; set; }
    public virtual ICollection<CandidateCompany> CandidateCompanies { get; set; }
}
