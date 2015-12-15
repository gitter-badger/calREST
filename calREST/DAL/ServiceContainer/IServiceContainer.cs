using System;
using System.Threading.Tasks;

namespace calREST.DAL
{
   public interface IServiceContainer
    {
        int SubmitChanges();
        Task<int> SubmitAsync();
    }
}
