using System.ComponentModel.DataAnnotations;

namespace GestionCVForum.Models.Domain
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Skills { get; set; }
        public string CVPath { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<CandidateCompany> CandidateCompanies { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
    }

}
