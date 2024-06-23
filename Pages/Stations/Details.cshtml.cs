using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FloodingApp.Models;

namespace FloodingApp.Pages.Stations
{
    public class DetailsModel : PageModel
    {
        private readonly FloodMonitoringContext _context;

        public DetailsModel(FloodMonitoringContext context)
        {
            _context = context;
        }

        public Station Station { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Station = await _context.Stations
                .Include(s => s.Values.OrderByDescending(v => v.TimeStamp).Take(5))
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Station == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
