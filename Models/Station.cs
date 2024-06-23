using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FloodingApp.Models
{
    public class Station
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Range(1, 10, ErrorMessage = "Flood Warning Value must be between 1 and 10")]
        public int FloodWarningValue { get; set; }

        [Range(1, 10, ErrorMessage = "Drought Warning Value must be between 1 and 10")]
        public int DroughtWarningValue { get; set; }

        [Range(1, 1440, ErrorMessage = "Time Tolerance must be between 1 and 1440 minutes")]
        public int TimeToleranceInMin { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string CreatedByUser { get; set; }

        public List<Value> Values { get; set; } = new List<Value>();
    }
}
