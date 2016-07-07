using IdentityJwtOwin.Infrastructure;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;


/*
Install-Package Microsoft.AspNet.WebApi.Owin 
Install-Package Microsoft.Owin.Host.SystemWeb
Install-Package Microsoft.AspNet.Identity.Owin
Install-Package Microsoft.AspNet.Identity.EntityFramework
Install-Package Microsoft.Owin.Security.OAuth 
Install-Package Microsoft.Owin.Cors

Install-Package System.IdentityModel.Tokens.Jwt -Version 4.0.0
Install-Package Microsoft.Owin.Security.Jwt

    */


[assembly: OwinStartup(typeof(IdentityJwtOwin.Startup))]
namespace IdentityJwtOwin
{
   
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();            
            WebApiConfig.Register(config);
                        
             app
               .UseOAuthAuthorizationServer(new OAuthOptions())
               .UseJwtBearerAuthentication(new JwtOptions())
               .UseCors(CorsOptions.AllowAll)
               .UseWebApi(config);
        }

    }
}