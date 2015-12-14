using calREST.Domain;
using calREST.DTOs;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;


namespace calREST.DAL.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _ctx;

        private UserManager<ApplicationUser> _userManager;

        public UserService(ApplicationDbContext ctx, UserManager<ApplicationUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                Email = userModel.Email,
                UserName = userModel.Email
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (result.Succeeded)
            {
                // if succeed create a calendar
                _ctx.Calendars.Add(new Calendar
                {
                    Id = _userManager.FindByEmail(userModel.Email).Id,
                    StartTime = new TimeSpan(8, 0, 0),
                    Interval = new TimeSpan(0, 45, 0),
                    EndTime = new TimeSpan(20, 0, 0)
                });

                _ctx.SaveChanges();
            }
               

            return result;
        }

        public async Task<ApplicationUser> FindUser(string username, string password)
        {
            ApplicationUser user = await _userManager.FindAsync(username, password);
          
            return user;
        }

        public async Task<ApplicationUser> FindUserById(string UserId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(UserId);

            return user;
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }
    }
}