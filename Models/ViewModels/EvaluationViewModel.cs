using System.ComponentModel.DataAnnotations;

namespace GestionCVForum.Models.ViewModels
{
    public class EvaluationViewModel
    {
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public string Comments { get; set; }

        public int ForumId { get; set; }
    }
}
