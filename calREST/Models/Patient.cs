using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace calREST.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [ForeignKey("User")]
        public string OwnerId { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }

        [Required]
        public string PatientName { get; set; }

        public string PhoneNumber { get; set; }
        public string Note { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

    }
}