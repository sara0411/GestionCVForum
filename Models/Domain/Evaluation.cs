using System.ComponentModel.DataAnnotations;

namespace GestionCVForum.Models.Domain
{
    public class Evaluation
    {
        public int EvaluationId { get; set; }
        public int CandidateId { get; set; }
        public int RecruiterId { get; set; }
        public int ForumId { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime EvaluationDate { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Recruiter Recruiter { get; set; }
        public virtual Forum Forum { get; set; }
    }

}
