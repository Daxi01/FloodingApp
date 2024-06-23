using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FloodingApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace FloodingApp.Pages.Stations
{
    public class IndexModel : PageModel
    {
        private readonly FloodMonitoringContext _context;

        public IndexModel(FloodMonitoringContext context)
        {
            _context = context;
        }

        public IList<Station> Stations { get; set; }

        public async Task OnGetAsync()
        {
            Stations = await _context.Stations
                .Include(s => s.Values.OrderByDescending(v => v.TimeStamp).Take(1))
                .ToListAsync();
        }
    }
}
