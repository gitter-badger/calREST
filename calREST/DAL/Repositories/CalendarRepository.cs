using calREST.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using calREST.DAL.GenericRepository;
using calREST.DTOs;
using System;

namespace calREST.DAL.Repositories
{
    public class CalendarRepository : EntityRepository<Calendar, string>, ICalendarRepository 
    {
        public CalendarRepository(ApplicationDbContext ctx) 
            : base(ctx) 
        {
          
        }

        public void AddDefaultCalendar(ApplicationUser user)
        {
            // Calendar ID and User ID is the same as they have 1-1 relationship.
            this.Add(new Calendar
            {
                User = user,
                StartTime = new TimeSpan(8, 0, 0),
                Interval = new TimeSpan(0, 45, 0),
                EndTime = new TimeSpan(20, 0, 0)
            });
        }
    }
}
