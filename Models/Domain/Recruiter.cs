using System.ComponentModel.DataAnnotations;

namespace GestionCVForum.Models.Domain
{
    public class Recruiter
    {
        public int RecruiterId { get; set; }
        public string UserId { get; set; }
        public int CompanyId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
    }

}
