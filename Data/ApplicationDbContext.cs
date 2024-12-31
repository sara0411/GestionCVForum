using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GestionCVForum.Models.Domain;

namespace GestionCVForum.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Forum> Forums { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<ForumCompany> ForumCompanies { get; set; }
        public DbSet<CandidateCompany> CandidateCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ForumCompany>()
                .HasKey(fc => new { fc.ForumId, fc.CompanyId });

            modelBuilder.Entity<CandidateCompany>()
                .HasKey(cc => new { cc.CandidateId, cc.CompanyId, cc.ForumId });

            modelBuilder.Entity<Recruiter>()
                .HasOne(r => r.Company)
                .WithMany(c => c.Recruiters)
                .HasForeignKey(r => r.CompanyId);
        }
    }

}