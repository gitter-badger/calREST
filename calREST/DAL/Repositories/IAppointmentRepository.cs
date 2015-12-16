using calREST.Domain;
using System.Collections.Generic;
using calREST.DAL.GenericRepository;
using calREST.DTOs;

namespace calREST.DAL.Repositories
{
    public interface IAppointmentRepository : IEntityRepository<Appointment, int>
    {
        IEnumerable<AppointmentDTO> GetAppointmentsByUser(string userId);
    }
}
