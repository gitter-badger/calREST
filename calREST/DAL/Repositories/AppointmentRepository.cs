using calREST.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using calREST.DAL.GenericRepository;
using calREST.DTOs;
using calREST.Utilities;

namespace calREST.DAL.Repositories
{
    public class AppointmentRepository : EntityRepository<Appointment, int>, IAppointmentRepository 
    {
        private readonly DTOFactory _dtoFactory;

        public AppointmentRepository(ApplicationDbContext ctx, DTOFactory dtoFactory) 
            : base(ctx) 
        {
            _dtoFactory = dtoFactory;
        }
        
        public IEnumerable<AppointmentDTO> GetAppointmentsByUser (string userId)
        {
            var appointments = this.GetAllIncluding(a => a.Patient)
                .Include(a => a.User)
                .Where(x => x.CalendarId == userId);

            return appointments.ToList().Select(a => _dtoFactory.Create(a));
           
        }      
    }
}
