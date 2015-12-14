using calREST.Domain;
using System.Threading.Tasks;
using calREST.DAL.Repositories;
using System;
using calREST.DAL.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace calREST.DAL
{
    public class ApplicationService : IApplicationService
    {
        private ApplicationDbContext _context;

        public ApplicationService(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        private IAppointmentRepository appointmentRepository;
        private IUserService userService;

        public IAppointmentRepository AppointmentRepository
        {
            get
            {
                if (this.appointmentRepository == null)
                {
                    this.appointmentRepository = new AppointmentRepository(_context);
                }
                return appointmentRepository;
            }

       }
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

        public void Dispose()
        {
            this._context.Dispose();
            this.userService.Dispose();
        }
    }
}