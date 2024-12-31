using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace GestionCVForum.Models.ViewModels
{
    public class CandidateSubmissionViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Skills { get; set; }

        [Required]
        [Display(Name = "CV File")]
        public IFormFile CV { get; set; }

        [Required]
        [Display(Name = "Companies")]
        public List<int> SelectedCompanyIds { get; set; }
    }
}