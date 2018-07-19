using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SarcramentPlannerRazor.Models;

namespace SarcramentPlannerRazor.Pages.SacPrograms
{
    public class EditModel : PageModel
    {
        private readonly SarcramentPlannerRazor.Models.SarcramentContext _context;

        public EditModel(SarcramentPlannerRazor.Models.SarcramentContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SacProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SacProgramExists(SacProgram.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SacProgramExists(int id)
        {
            return _context.SacProgram.Any(e => e.ID == id);
        }
    }
}
