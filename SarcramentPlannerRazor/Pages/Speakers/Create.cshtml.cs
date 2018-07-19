using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SarcramentPlannerRazor.Models;

namespace SarcramentPlannerRazor.Pages.Speakers
{
    public class CreateModel : PageModel
    {
        private readonly SarcramentPlannerRazor.Models.SarcramentContext _context;

        public CreateModel(SarcramentPlannerRazor.Models.SarcramentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SacProgramID"] = new SelectList(_context.Set<SacProgram>(), "ID", "ClosingHymn");
            return Page();
        }

        [BindProperty]
        public Speaker Speaker { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Speaker.Add(Speaker);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}