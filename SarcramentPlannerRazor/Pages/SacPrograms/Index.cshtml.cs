using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SarcramentPlannerRazor.Models;
using SarcramentPlannerRazor.Models.SacProgramViewModels;

namespace SarcramentPlannerRazor.Pages.SacPrograms
{
    public class IndexModel : PageModel
    {
        private readonly SarcramentContext _context;

        public IndexModel(SarcramentContext context)
        {
            _context = context;
        }

        public SacProgramIndexData SacProgram { get;set; }
        public int SacProgramID { get; set; }
        public int SpeakerID { get; set; }

        public async Task OnGetAsync(int? id, int? speakerID)
        {
            SacProgram = new SacProgramIndexData();
            SacProgram.SacPrograms = await _context.SacProgram
                  .Include(i => i.Speakers)
                    //.ThenInclude(i => i.Speaker)
                  .AsNoTracking()
                  .OrderBy(i => i.Date)
                  .ToListAsync();

            if (id != null)
            {
                SacProgramID = id.Value;
                SacProgram sacProgram = SacProgram.SacPrograms.Where(
                    i => i.ID == id.Value).Single();
                SacProgram.Speakers = sacProgram.Speakers;
            }

            if (speakerID != null)
            {
                SpeakerID = speakerID.Value;
                //Instructor.Enrollments = SacProgram.Speakers.Where(
                //    x => x.SpeakerID == speakerID).Single().SpeakerName;
            }
        }
    }
}