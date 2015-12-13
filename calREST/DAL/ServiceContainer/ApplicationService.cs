using calREST.Domain;
using System.Threading.Tasks;
using calREST.DAL.ServiceUnits;
using System;

namespace calREST.DAL
{
    public class ApplicationService : IApplicationService
    {
        private ApplicationDbContext _context;

        private IAppointmentService appointmentService;

        public IAppointmentService AppointmentService
        {
            get
            {
                if (this.appointmentService == null)
                {
                    this.appointmentService = new AppointmentService(_context);
                }
                return appointmentService;
            }

       }

        public ApplicationService(ApplicationDbContext ctx)
        {
            _context = ctx;
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
        }
    }
}