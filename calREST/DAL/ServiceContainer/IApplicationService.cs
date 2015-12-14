using calREST.DAL.Repositories;
using calREST.DAL.Services;

namespace calREST.DAL
{
    public interface IApplicationService : IServiceContainer
    {
        IAppointmentRepository AppointmentRepository { get;}
        IUserService UserService { get; }
    }
}
