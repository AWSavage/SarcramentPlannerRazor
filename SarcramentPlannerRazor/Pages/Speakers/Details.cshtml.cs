using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SarcramentPlannerRazor.Models;

namespace SarcramentPlannerRazor.Pages.Speakers
{
    public class DetailsModel : PageModel
    {
        private readonly SarcramentPlannerRazor.Models.SarcramentContext _context;

        public DetailsModel(SarcramentPlannerRazor.Models.SarcramentContext context)
        {
            _context = context;
        }

        public Speaker Speaker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Speaker = await _context.Speaker
                .Include(s => s.SacProgram).FirstOrDefaultAsync(m => m.SpeakerID == id);

            if (Speaker == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
