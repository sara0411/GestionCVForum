using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GestionCVForum.Models.ViewModels
{
    public class ForumViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        [Display(Name = "Companies")]
        public List<int> SelectedCompanyIds { get; set; }
    }
}