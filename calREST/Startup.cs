using calREST.Domain;
using calREST.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Ninject.Web.WebApi.OwinHost;
using Ninject.Web.Common.OwinHost;
using Owin;
using System;
using System.Web.Http;


namespace calREST
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            HttpConfiguration config = new HttpConfiguration();
        
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseNinjectMiddleware(NinjectConfig.CreateKernel).UseNinjectWebApi(config);
            //app.UseWebApi(config);
        }

        public static string PublicClientId { get; private set; }

        public void ConfigureOAuth(IAppBuilder app)
        {
           app.CreatePerOwinContext(ApplicationDbContext.Create);
           app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            PublicClientId = "Self";

        OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new ApplicationOAuthProvider(PublicClientId)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
     

        }

       
    }
}