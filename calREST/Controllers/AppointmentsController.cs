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

namespace calREST.Controllers
{
    [Authorize]
    public class AppointmentsController : ApiController
    {
        private IApplicationService _appService;

        public AppointmentsController(IApplicationService appService)
        {
            _appService = appService;
          
        }

        //This constructor will be removed when DI will take place.
        public AppointmentsController()
        {
            _appService  = new ApplicationService(new ApplicationDbContext());
        }

      

        // GET: api/Appointments
        public IEnumerable<AppointmentDTO> GetAppointments()
        {
            using (ApplicationService sc = new ApplicationService(new ApplicationDbContext()))
            {
              return  sc.AppointmentService.GetAppointmentsByUser(User.Identity.GetUserId());

            }                   
        }

        // GET: api/Appointments/5
        [ResponseType(typeof(Appointment))]
        public async Task<IHttpActionResult> GetAppointment(int id)
        {
            Appointment appointment = await _appService.AppointmentService.DbSet.FindAsync(id);
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
            
            _appService._context.Entry(appointment).State = EntityState.Modified;

            try
            {
               await _appService.SubmitAsync();
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

                     
            _appService.AppointmentService.DbSet.Add(appointment);
            await _appService.SubmitAsync();

            return CreatedAtRoute("DefaultApi", new { id = appointment.AppointmentId }, appointment);
        }

        // DELETE: api/Appointments/5
        [ResponseType(typeof(Appointment))]
        public async Task<IHttpActionResult> DeleteAppointment(int id)
        {
            Appointment appointment = await _appService.AppointmentService.DbSet.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _appService.AppointmentService.DbSet.Remove(appointment);
            await _appService.SubmitAsync();
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
            return _appService.AppointmentService.DbSet.Count(e => e.AppointmentId == id) > 0;
        }
    }
}