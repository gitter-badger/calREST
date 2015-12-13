using calREST.DAL.GenericRepository;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace calREST.Domain
{
    public class Appointment : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }
        [Required]
        public DateTimeOffset EndDate { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Calendar")]
        public string CalendarId { get; set; }
        [JsonIgnore]
        public  Calendar Calendar { get; set; }

        [ForeignKey("User")]
        public string CreatorId { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }

       
    }
}