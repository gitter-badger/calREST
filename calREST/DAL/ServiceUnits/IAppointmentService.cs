using calREST.Domain;
using System.Collections.Generic;
using calREST.DAL.GenericRepository;

namespace calREST.DAL.ServiceUnits
{
    public interface IAppointmentService : IEntityRepository<Appointment, int>
    {
        IEnumerable<AppointmentDTO> GetAppointmentsByUser(string userId);
    }
}
