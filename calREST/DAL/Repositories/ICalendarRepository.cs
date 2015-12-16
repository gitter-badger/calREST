using calREST.Domain;
using System.Collections.Generic;
using calREST.DAL.GenericRepository;

namespace calREST.DAL.Repositories
{
    public interface ICalendarRepository : IEntityRepository<Calendar, string>
    {
        void AddDefaultCalendar(string userId);
    }
}
