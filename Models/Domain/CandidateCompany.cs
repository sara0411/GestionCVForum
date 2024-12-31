namespace GestionCVForum.Models.Domain
{
    public class CandidateCompany
    {
        public int CandidateId { get; set; }
        public int CompanyId { get; set; }
        public int ForumId { get; set; }
        public DateTime ApplicationDate { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Company Company { get; set; }
        public virtual Forum Forum { get; set; }
    }
}
