using calREST.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calREST.DTOs
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public int? PatientId { get; set; }
        public Patient Patient { get; set; }

        public string CalendarId { get; set; }

        public UserInfoModel Creator { get; set; }
    }
}