using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SarcramentPlannerRazor.Models;

namespace SarcramentPlannerRazor.Pages.SacPrograms
{
    public class CreateModel : PageModel
    {
        private readonly SarcramentContext _context;

        public CreateModel(SarcramentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SacProgram SacProgram { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SacProgram.Add(SacProgram);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}