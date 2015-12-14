﻿using calREST.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using calREST.DAL.GenericRepository;
using calREST.DTOs;

namespace calREST.DAL.Repositories
{
    public class AppointmentRepository : EntityRepository<Appointment, int>, IAppointmentRepository 
    {
        public AppointmentRepository(ApplicationDbContext ctx) 
            : base(ctx) 
        {
          
        }
        
        public IEnumerable<AppointmentDTO> GetAppointmentsByUser (string userId)
        {
            var appointments = this.GetAllIncluding(a => a.Patient).Include(a => a.User).Where(x => x.CalendarId == userId);
            List<AppointmentDTO> appointmentsDto = new List<AppointmentDTO>();
            foreach (var a in appointments)
            {
                appointmentsDto.Add(new AppointmentDTO
                {
                    AppointmentId = a.Id,
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