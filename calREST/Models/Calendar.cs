using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace calREST.Models
{
    public class Calendar
    {
        [Key, ForeignKey("User")]
        public string CalendarId { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }

        public TimeSpan Interval { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

      
    }
}