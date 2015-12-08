using calREST.DAL.ServiceUnits;
using calREST.Models;
using System.Threading.Tasks;

namespace calREST.DAL
{
    public interface IApplicationService
    {
        ApplicationDbContext Context { get; }

        IAppointmentService AppointmentService { get;}
      
        int SubmitChanges();
        Task<int> SubmitAsync();
    }
}
