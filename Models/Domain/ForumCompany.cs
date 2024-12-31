namespace GestionCVForum.Models.Domain
{
    public class ForumCompany
    {
        public int ForumId { get; set; }
        public int CompanyId { get; set; }

        public virtual Forum Forum { get; set; }
        public virtual Company Company { get; set; }
    }
}
