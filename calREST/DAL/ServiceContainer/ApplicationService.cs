using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using calREST.Models;
using System.Threading.Tasks;
using calREST.DAL.ServiceUnits;

namespace calREST.DAL
{
    public class ApplicationService : IApplicationService
    {
        public ApplicationDbContext Context { get;}

        private AppointmentService appointmentService;

        public IAppointmentService AppointmentService
        {
            get
            {
                if (this.appointmentService == null)
                {
                    this.appointmentService = new AppointmentService(Context);
                }
                return appointmentService;
            }

       }

        public ApplicationService(ApplicationDbContext ctx)
        {
            Context = ctx;
        }

        public int SubmitChanges()
        {
            return this.Context.SaveChanges();
     
        }

        public async Task<int> SubmitAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}