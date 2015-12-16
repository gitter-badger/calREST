using calREST.Domain;
using calREST.DTOs;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace calREST.DAL.Services
{
    public interface IUserService : IDisposable
    {
        Task<IdentityResult> RegisterUser(UserModel userModel);
        Task<ApplicationUser> FindUser(string username, string password);
        Task<ApplicationUser> FindUserById(string UserId);
        string GetUserIdByEmail(string email);
    }
}