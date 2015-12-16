using calREST.DAL.GenericRepository;
using calREST.DAL.Repositories;
using calREST.DAL.Services;
using calREST.Domain;

namespace calREST.DAL
{
    public interface IApplicationService : IServiceContainer
    {
        IAppointmentRepository AppointmentRepo { get;}
        ICalendarRepository CalendarRepo { get; set; }
        IEntityRepository<Patient,int> PatientRepo { get; set; }
        IUserService UserService { get; }
    }
}
