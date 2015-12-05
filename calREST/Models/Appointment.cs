﻿using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace calREST.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public string Content { get; set; }

        [ForeignKey("Calendar")]
        public string CalendarId { get; set; }
        [JsonIgnore]
        public virtual Calendar Calendar { get; set; }

        [ForeignKey("User")]
        public string CreatorId { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }
    }
}