using calREST.Domain;
using calREST.DAL.GenericRepository;

namespace calREST.DAL.Repositories
{
    public interface ICalendarRepository : IEntityRepository<Calendar, string>
    {
        void AddDefaultCalendar(ApplicationUser user);
    }
}
