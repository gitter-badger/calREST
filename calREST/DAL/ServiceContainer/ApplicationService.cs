using calREST.Domain;
using System.Threading.Tasks;
using calREST.DAL.Repositories;
using System;
using calREST.DAL.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using calREST.DAL.GenericRepository;

namespace calREST.DAL
{
    public class ApplicationService : IApplicationService
    {
        private readonly ApplicationDbContext _context;

        public ApplicationService(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        private IUserService userService;

        [Inject]
        public IAppointmentRepository AppointmentRepo { get; set; }
        [Inject]
        public ICalendarRepository CalendarRepo { get; set; }
        [Inject]
        public IEntityRepository<Patient, int> PatientRepo { get; set; }

        public IUserService UserService
        {
            get
            {
                if (this.userService == null)
                {
                    this.userService = new UserService(_context, new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context)));
                }
                return userService;
            }
        }

             
        public int SubmitChanges()
        {
            return this._context.SaveChanges();
     
        }

        public async Task<int> SubmitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        //Dispose any services that is not injected by DI
        public void Dispose()
        {
            if (this.userService != null)
                userService.Dispose();
        }
    }
}