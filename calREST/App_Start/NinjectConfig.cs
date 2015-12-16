using calREST.DAL;
using calREST.DAL.GenericRepository;
using calREST.DAL.Repositories;
using calREST.Domain;
using calREST.Utilities;
using Ninject;
using Ninject.Web.Common;
using System.Data.Entity;
using System.Reflection;

namespace calREST
{
    public static class NinjectConfig
    {

        public static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterServices(kernel);
            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            //Context
            kernel.Bind<ApplicationDbContext, DbContext>().To<ApplicationDbContext>().InRequestScope();

            //Services
            kernel.Bind<IApplicationService>().To<ApplicationService>().InRequestScope();

            //Repos
            kernel.Bind<IAppointmentRepository>().To<AppointmentRepository>().InRequestScope();
            kernel.Bind<ICalendarRepository>().To<CalendarRepository>().InRequestScope();
            //Generic Repos resolved by type
            kernel.Bind(typeof(IEntityRepository<,>)).To(typeof(EntityRepository<,>)).InRequestScope();

            //Utilities
            kernel.Bind<DTOFactory>().ToSelf().InSingletonScope();
            
        }
    }
}