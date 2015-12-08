using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using calREST.Models;
using System.Threading.Tasks;

namespace calREST.DAL
{
    public class ApplicationService : IApplicationService, IDisposable
    {
        public ApplicationDbContext _context { get;}

        private AppointmentService appointmentService;

        public AppointmentService AppointmentService
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

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SubmitChanges()
        {
            return this._context.SaveChanges();
     
        }

        public async Task<int> SubmitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}