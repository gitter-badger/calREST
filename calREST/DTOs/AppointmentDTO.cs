using calREST.Domain;
using System;
using System.ComponentModel.DataAnnotations;


namespace calREST.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }
        [Required]
        public DateTimeOffset EndDate { get; set; }

        public int? PatientId { get; set; }
        public Patient Patient { get; set; }

        public string CalendarId { get; set; }

        public UserInfoModel Creator { get; set; }
    }
}