using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SarcramentPlannerRazor.Models.SacProgramViewModels
{
    public class SacProgramIndexData
    {
        public IEnumerable<SacProgram> SacPrograms { get; set; }
        public IEnumerable<Speaker> Speakers { get; set; }
    }
}
