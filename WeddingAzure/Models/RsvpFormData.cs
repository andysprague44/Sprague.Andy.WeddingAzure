using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WeddingAzure.Models
{
    public class RsvpFormData
    {
        [Required(ErrorMessage = "* Name is required")]
        [Display(Name = "Name(s)")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "* Name must be between 2 and 100 characters.")]
        public string NameTextBoxData { get; set; }

        [Display(GroupName = "AttendingWedding", Name="Is ready to see you get married")]
        public bool AttendingWeddingCheckBox { get; set; }
        
        [Display(GroupName = "WillToastFromAfar", Name = "Will toast you from afar")]
        public bool WillToastFromAfar { get; set; }

        [Display(GroupName = "AttendingSunday", Name = "Will attend Pop in the Park")]
        public bool AttendingSundayCheckBox { get; set; }

        [Display(Name = "Dietary Requirements")]
        public string DietaryRequirementsTextBoxData { get; set; }
        
        [Display(Name = "I'll only dance if you play... ")]
        public string SongRequestTextBoxData { get; set; }
    }
}