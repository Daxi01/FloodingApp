using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using FloodingApp.Models;
using System.Threading.Tasks;
using System;

namespace FloodingApp.Pages.Stations
{
    public class CreateModel : PageModel
    {
        private readonly FloodMonitoringContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(FloodMonitoringContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Station Station { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("OnPostAsync called.");

            Station.CreatedByUser = "TestUser";

            ModelState.Clear();
            TryValidateModel(Station);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is not valid.");
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var value = ModelState[modelStateKey];
                    foreach (var error in value.Errors)
                    {
                        _logger.LogWarning($"Error in {modelStateKey}: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            _logger.LogInformation("ModelState is valid. Adding station.");
            Station.CreatedOn = DateTime.UtcNow;
            _context.Stations.Add(Station);

            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Station added and saved.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving station: {ex.Message}");
                throw; 
            }

            return RedirectToPage("./Index");
        }
    }
}
