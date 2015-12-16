using calREST.DAL;
using calREST.Domain;
using calREST.DTOs;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace calREST.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IApplicationService _as;

        public AccountController(IApplicationService appService)
        {
            _as = appService;
        }
   

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _as.UserService.RegisterUser(userModel);         

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }
            if (result.Succeeded)
                _as.CalendarRepo.AddDefaultCalendar(_as.UserService.GetUserIdByEmail(userModel.Email));          
                           
            _as.SubmitChanges();
            return Ok(userModel.Email);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
