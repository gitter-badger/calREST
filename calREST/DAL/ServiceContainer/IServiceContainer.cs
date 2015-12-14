using System;
using System.Threading.Tasks;

namespace calREST.DAL
{
   public interface IServiceContainer : IDisposable
    {
        int SubmitChanges();
        Task<int> SubmitAsync();
    }
}
