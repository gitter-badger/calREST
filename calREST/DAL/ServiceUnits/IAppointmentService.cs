using calREST.DTOs;
using calREST.Models;
using System.Collections.Generic;

namespace calREST.DAL.ServiceUnits
{
    public interface IAppointmentService : IGenericServiceUnit<Appointment>
    {
        IEnumerable<AppointmentDTO> GetAppointmentsByUser(string userId);
    }
}
