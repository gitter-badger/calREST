using calREST.DAL.GenericRepository;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace calREST.Domain
{
    public class Calendar: IEntity<string>
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }

        public TimeSpan Interval { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

      
    }
}