using calREST.DTOs;
using calREST.DAL.ServiceUnits;
using calREST.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace calREST.DAL
{
    public class AppointmentService:GenericServiceUnit<Appointment>, IAppointmentService
    {
        public AppointmentService(ApplicationDbContext ctx) 
            : base(ctx) 
        {
          
        }
        
        public IEnumerable<AppointmentDTO> GetAppointmentsByUser (string userId)
        {
            var appointments = DbSet.Include(a => a.Patient).Include(a => a.User).Where(x => x.CalendarId == userId);
            List<AppointmentDTO> appointmentsDto = new List<AppointmentDTO>();
            foreach (var a in appointments)
            {
                appointmentsDto.Add(new AppointmentDTO
                {
                    AppointmentId = a.AppointmentId,
                    CalendarId = a.CalendarId,
                    Creator = new UserInfoModel { Name = a.User.UserName, Id = a.User.Id },
                    EndDate = a.EndDate,
                    StartDate = a.StartDate,
                    Patient = a.Patient,
                    PatientId = a.PatientId
                });
            }
            return appointmentsDto;
        }      
    }
}
