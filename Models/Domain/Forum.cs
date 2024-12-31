using System.ComponentModel.DataAnnotations;

namespace GestionCVForum.Models.Domain
{
    public class Forum
    {
        public int ForumId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<ForumCompany> ForumCompanies { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
    }

}
