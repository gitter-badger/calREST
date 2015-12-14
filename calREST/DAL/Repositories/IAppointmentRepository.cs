using calREST.Domain;
using System.Collections.Generic;
using calREST.DAL.GenericRepository;

namespace calREST.DAL.Repositories
{
    public interface IAppointmentRepository : IEntityRepository<Appointment, int>
    {
        IEnumerable<AppointmentDTO> GetAppointmentsByUser(string userId);
    }
}
