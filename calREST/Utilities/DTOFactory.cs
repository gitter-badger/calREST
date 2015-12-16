using calREST.Domain;
using calREST.DTOs;

namespace calREST.Utilities
{
    public class DTOFactory
    {
        public AppointmentDTO Create(Appointment appointment)
        {
            return new AppointmentDTO()
            {
                Id = appointment.Id,
                CalendarId = appointment.CalendarId,
                Creator = Create(appointment.User)
            };
        }

        public UserInfoModel Create(ApplicationUser user)
        {
            return new UserInfoModel()
            {
                Id = user.Id,
                Name = user.UserName
            };
        }

        
    }
}