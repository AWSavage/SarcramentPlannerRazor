using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SarcramentPlannerRazor.Models
{
    public class Speaker
    {
        public int SpeakerID { get; set; }

        [Display(Name = "Sacrament Program")]
        public int SacProgramID { get; set; }

        [Display(Name = "Name")]
        public String SpeakerName { get; set; }
        public String Topic { get; set; }

        [Display(Name = "Speaker Order")]
        public String SpeakerOrder { get; set; }

        public SacProgram SacProgram { get; set; }
    }
}
