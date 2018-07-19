using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SarcramentPlannerRazor.Models;

namespace SarcramentPlannerRazor.Models
{
    public class SarcramentContext : DbContext
    {
        public SarcramentContext (DbContextOptions<SarcramentContext> options)
            : base(options)
        {
        }

        public DbSet<SarcramentPlannerRazor.Models.Speaker> Speaker { get; set; }

        public DbSet<SarcramentPlannerRazor.Models.SacProgram> SacProgram { get; set; }
    }
}
