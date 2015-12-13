using calREST.DAL.GenericRepository;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace calREST.Domain
{
    public class Patient:IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string OwnerId { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }

        [Required]
        public string PatientName { get; set; }

        public string PhoneNumber { get; set; }
        public string Note { get; set; }
        public DateTimeOffset CreationDate { get; set; } = DateTime.Now;

    }
}