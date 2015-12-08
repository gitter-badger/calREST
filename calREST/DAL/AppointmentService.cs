using calREST.DTOs;
using calREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calREST.DAL
{
    public class AppointmentService:GenericService<Appointment>
    {
        public AppointmentService(ApplicationDbContext ctx) 
            : base(ctx) 
        {
          
        }
        
        public IEnumerable<AppointmentDTO> GetAppointmentsByUser (string userId)
        {
            var appointments = DbSet.Include("Patient").Include("User").Where(x => x.CalendarId == userId);
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
