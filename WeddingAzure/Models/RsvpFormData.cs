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
        [Display(Name = "Name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "* Name must be between 2 and 100 characters.")]
        public string NameTextBoxData { get; set; }
        
        [Display(GroupName = "AttendingWedding", Name="Yes, I'll be attending your wedding!", Description = "Saturday 26th May 2:30pm")]
        public bool AttendingWeddingCheckBox { get; set; }
        
        [Display(GroupName = "AttendingSunday", Name = "Yes, I'll be at Pop in the Park!", Description = "Sunday 27th May 2pm-5pm")]
        public bool AttendingSundayCheckBox { get; set; }

        [Display(Name = "Dietary Requirements")]
        public string DietaryRequirementsTextBoxData { get; set; }
        
        [Display(Name = "If you play this then I'll dance... ", Prompt = "Title, Artist")]
        public string SongRequestTextBoxData { get; set; }
    }
}