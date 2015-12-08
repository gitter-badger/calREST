using calREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calREST.DAL
{
    public interface IApplicationService
    {
        AppointmentService AppointmentService { get;}
        ApplicationDbContext _context { get; }

        int SubmitChanges();
        Task<int> SubmitAsync();
    }
}
