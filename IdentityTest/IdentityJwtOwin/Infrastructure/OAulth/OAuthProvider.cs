using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace IdentityJwtOwin.Infrastructure
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {

        public async override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {


            var xx = context.Options.AuthenticationType;

            var identity = new ClaimsIdentity("otc");
            var username = context.OwinContext.Get<string>("otc:username");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username));
            identity.AddClaim(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "user"));
            context.Validated(identity);
            
        }


        public async override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            try
            {
                var username = context.Parameters["username"];
                var password = context.Parameters["password"];
                

                using (AuthRepository _repo = new AuthRepository())
                {
                    IdentityUser user = await _repo.FindUser(username, password);

                    if (user == null)
                    {
                        context.SetError("invalid_grant", "The user name or password is incorrect.");
                        context.Rejected();
                    }
                    else
                    {
                        context.OwinContext.Set("otc:username", username);
                        context.Validated();
                    }
                    

                }

                
            }
            catch
            {
                context.SetError("Server error");
                context.Rejected();
            }
            
        }
        
    }
}