using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FloodingApp.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace FloodingApp.Pages.Stations
{
    public class EditModel : PageModel
    {
        private readonly FloodMonitoringContext _context;
        private readonly ILogger<EditModel> _logger;

        public EditModel(FloodMonitoringContext context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Station Station { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Station = await _context.Stations.FindAsync(id);

            if (Station == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("OnPostAsync called.");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is not valid.");

                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        _logger.LogWarning($"Error in {state.Key}: {error.ErrorMessage}");
                    }
                }

                return Page();
            }

            var stationToUpdate = await _context.Stations.FindAsync(Station.Id);

            if (stationToUpdate == null)
            {
                _logger.LogWarning("Station not found.");
                return NotFound();
            }

            stationToUpdate.Title = Station.Title;
            stationToUpdate.FloodWarningValue = Station.FloodWarningValue;
            stationToUpdate.DroughtWarningValue = Station.DroughtWarningValue;
            stationToUpdate.TimeToleranceInMin = Station.TimeToleranceInMin;

            if (string.IsNullOrEmpty(stationToUpdate.CreatedByUser))
            {
                stationToUpdate.CreatedByUser = "system";
            }

            try
            {
                _context.Attach(stationToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Station updated successfully.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!StationExists(Station.Id))
                {
                    _logger.LogWarning("Station does not exist.");
                    return NotFound();
                }
                else
                {
                    _logger.LogError($"Concurrency error: {ex.Message}");
                    throw;
                }
            }

            return RedirectToPage("./Index"); 
        }

        private bool StationExists(int id)
        {
            return _context.Stations.Any(e => e.Id == id);
        }
    }
}
