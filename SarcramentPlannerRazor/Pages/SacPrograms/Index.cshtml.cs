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
    public class IndexModel : PageModel
    {
        private readonly SarcramentPlannerRazor.Models.SarcramentContext _context;

        public IndexModel(SarcramentPlannerRazor.Models.SarcramentContext context)
        {
            _context = context;
        }

        public IList<SacProgram> SacProgram { get;set; }

        public async Task OnGetAsync()
        {
            SacProgram = await _context.SacProgram.ToListAsync();
        }
    }
}
