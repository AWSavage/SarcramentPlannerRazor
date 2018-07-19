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
    public class DeleteModel : PageModel
    {
        private readonly SarcramentPlannerRazor.Models.SarcramentContext _context;

        public DeleteModel(SarcramentPlannerRazor.Models.SarcramentContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SacProgram = await _context.SacProgram.FindAsync(id);

            if (SacProgram != null)
            {
                _context.SacProgram.Remove(SacProgram);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
