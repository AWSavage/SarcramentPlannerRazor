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
    public class IndexModel : PageModel
    {
        private readonly SarcramentPlannerRazor.Models.SarcramentContext _context;

        public IndexModel(SarcramentPlannerRazor.Models.SarcramentContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }

        public IList<Speaker> Speaker { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CurrentFilter = searchString;

            IQueryable<Speaker> speakerIQ = from s in _context.Speaker
                                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                speakerIQ = speakerIQ.Where(s => s.SpeakerName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    speakerIQ = speakerIQ.OrderByDescending(s => s.SpeakerName);
                    break;
                default:
                    speakerIQ = speakerIQ.OrderBy(s => s.SpeakerName);
                    break;
            }

            Speaker = await speakerIQ.AsNoTracking()
                .Include(s => s.SacProgram).ToListAsync();
        }
    }
}
