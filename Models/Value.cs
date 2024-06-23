using System;
using System.ComponentModel.DataAnnotations;

namespace FloodingApp.Models
{
    public class Value
    {
        public Guid Id { get; set; }

        [Required]
        public int StationId { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        public int MeasurementValue { get; set; }
    }
}
