using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FloodingApp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FloodingApp.Pages.Stations
{
    public class DeleteModel : PageModel
    {
        private readonly FloodMonitoringContext _context;

        public DeleteModel(FloodMonitoringContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Station Station { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Station = await _context.Stations.FirstOrDefaultAsync(m => m.Id == id);

            if (Station == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Station = await _context.Stations.FindAsync(id);

            if (Station == null)
            {
                return NotFound();
            }

            _context.Stations.Remove(Station);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
