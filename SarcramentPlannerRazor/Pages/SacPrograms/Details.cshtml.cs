using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SarcramentPlannerRazor.Models;

namespace SarcramentPlannerRazor.Pages.SacPrograms
{
    public class DetailsModel : PageModel
    {
        private readonly SarcramentContext _context;

        public DetailsModel(SarcramentContext context)
        {
            _context = context;
        }

        public SacProgram SacProgram { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SacProgram = await _context.SacProgram.FirstOrDefaultAsync(m => m.ID == id);

            if (SacProgram == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
