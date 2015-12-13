using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using calREST.Domain;
using Microsoft.AspNet.Identity;
using calREST.DAL;

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
            Appointment appointment = _as.AppointmentService.GetSingle(id);
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

            if (id != appointment.Id)
            {
                return BadRequest();
            }

            _as.AppointmentService.Update(appointment);

            try
            {
               await _as.SubmitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_as.AppointmentService.Exists(id))
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

                     
            _as.AppointmentService.Add(appointment);
            await _as.SubmitAsync();

            return CreatedAtRoute("DefaultApi", new { id = appointment.Id }, appointment);
        }

        // DELETE: api/Appointments/5
        [ResponseType(typeof(Appointment))]
        public async Task<IHttpActionResult> DeleteAppointment(int id)
        {
            Appointment appointment = await _as.AppointmentService.FindBy(x => x.Id == id).FirstOrDefaultAsync();
            if (appointment == null)
            {
                return NotFound();
            }

            _as.AppointmentService.Delete(appointment);
            await _as.SubmitAsync();
            return Ok(appointment);
        }

       
    }
}