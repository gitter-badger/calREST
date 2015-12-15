using calREST.DAL;
using calREST.Domain;
using Ninject;
using Ninject.Web.Common;
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
            kernel.Bind<ApplicationDbContext>().To<ApplicationDbContext>().InRequestScope();
            kernel.Bind<IApplicationService>().To<ApplicationService>().InRequestScope();
        }
    }
}