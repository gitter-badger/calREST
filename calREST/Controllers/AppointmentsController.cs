using System;
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
using calREST.DAL;
using calREST.DAL.ServiceUnits;

namespace calREST.Controllers
{
    [Authorize]
    public class AppointmentsController : ApiController
    {
        private IApplicationService _as;

        public AppointmentsController(IApplicationService appService)
        {
            _as = appService;
          
        }

        //This constructor will be removed when DI will take place.
        public AppointmentsController()
        {
            _as  = new ApplicationService(new ApplicationDbContext());
        }

      

        // GET: api/Appointments
        public IEnumerable<AppointmentDTO> GetAppointments()
        {     
              return _as.AppointmentService.GetAppointmentsByUser(User.Identity.GetUserId());                 
        }

        // GET: api/Appointments/5
        [ResponseType(typeof(Appointment))]
        public async Task<IHttpActionResult> GetAppointment(int id)
        {
            Appointment appointment = await _as.AppointmentService.DbSet.FindAsync(id);
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
            
            _as.Context.Entry(appointment).State = EntityState.Modified;

            try
            {
               await _as.SubmitAsync();
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

                     
            _as.AppointmentService.DbSet.Add(appointment);
            await _as.SubmitAsync();

            return CreatedAtRoute("DefaultApi", new { id = appointment.AppointmentId }, appointment);
        }

        // DELETE: api/Appointments/5
        [ResponseType(typeof(Appointment))]
        public async Task<IHttpActionResult> DeleteAppointment(int id)
        {
            Appointment appointment = await _as.AppointmentService.DbSet.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _as.AppointmentService.DbSet.Remove(appointment);
            await _as.SubmitAsync();
            return Ok(appointment);
        }

        //This will be handled by DI.
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _sc.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool AppointmentExists(int id)
        {
            return _as.AppointmentService.DbSet.Count(e => e.AppointmentId == id) > 0;
        }
    }
}