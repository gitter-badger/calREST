using calREST.DAL.ServiceUnits;
using System;

namespace calREST.DAL
{
    public interface IApplicationService : IService
    {
        IAppointmentService AppointmentService { get;}
      
    }
}
