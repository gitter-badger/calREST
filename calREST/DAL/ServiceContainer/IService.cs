using System;
using System.Threading.Tasks;

namespace calREST.DAL
{
   public interface IService : IDisposable
    {
        int SubmitChanges();
        Task<int> SubmitAsync();
    }
}
