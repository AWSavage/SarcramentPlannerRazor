using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SarcramentPlannerRazor.Models
{
    public class SacProgram
    {
        public int ID { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Conducting")]
        public string Conducting { get; set; }
        [Required]
        [Display(Name = "Opening Hymn")]
        public string OpeningHymn { get; set; }
        [Required]
        [Display(Name = "Opening Prayer")]
        public string OpeningPrayer { get; set; }
        [Required]
        [Display(Name = "Sacrament Hymn")]
        public string SacramentHymn { get; set; }

        [Display(Name = "Intermediate Hymn")]
        public string IntermediateHymn { get; set; }

        [Required]
        [Display(Name = "Closing Hymn")]
        public string ClosingHymn { get; set; }
        [Required]
        [Display(Name = "Closing Prayer")]
        public string ClosingPrayer { get; set; }
        public ICollection<Speaker> Speakers { get; set; }
    }
}
