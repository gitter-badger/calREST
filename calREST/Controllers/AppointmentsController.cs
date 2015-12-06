﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using calREST.Models;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using calREST.DTOs;

namespace calREST.Controllers
{
    [Authorize]
    public class AppointmentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Appointments
        public List<AppointmentDTO> GetAppointments()
        {
            var userId = User.Identity.GetUserId();
            var appointments = db.Appointments.Where(x => x.CalendarId == userId).ToList();
            List<AppointmentDTO> appointmentsDto = new List<AppointmentDTO>();
            foreach (var a in appointments)
            {
                appointmentsDto.Add(new AppointmentDTO
                { AppointmentId = a.AppointmentId,
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

        // GET: api/Appointments/5
        [ResponseType(typeof(Appointment))]
        public async Task<IHttpActionResult> GetAppointment(int id)
        {
            Appointment appointment = await db.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        // PUT: api/Appointments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointment.AppointmentId)
            {
                return BadRequest();
            }

            db.Entry(appointment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Appointments
        [ResponseType(typeof(Appointment))]
        public async Task<IHttpActionResult> PostAppointment(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            appointment.CreatorId = User.Identity.GetUserId();
            appointment.CalendarId = User.Identity.GetUserId();

                     
            db.Appointments.Add(appointment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = appointment.AppointmentId }, appointment);
        }

        // DELETE: api/Appointments/5
        [ResponseType(typeof(Appointment))]
        public async Task<IHttpActionResult> DeleteAppointment(int id)
        {
            Appointment appointment = await db.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            db.Appointments.Remove(appointment);
            await db.SaveChangesAsync();

            return Ok(appointment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppointmentExists(int id)
        {
            return db.Appointments.Count(e => e.AppointmentId == id) > 0;
        }
    }
}