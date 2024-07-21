using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FloodingApp.Models
{
    public class Station
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int FloodWarningValue { get; set; }

        public int DroughtWarningValue { get; set; }

        public int TimeToleranceInMin { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string CreatedByUser { get; set; }

        public List<Value> Values { get; set; } = new List<Value>();
    }
}
