using Microsoft.Owin.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityJwtOwin.Infrastructure
{
    public class JwtOptions : JwtBearerAuthenticationOptions
    {
        public JwtOptions()
        {
            
            var issuer = "localhost";
            var key = Convert.FromBase64String(AuthConstants.JWT_KEY);

            AllowedAudiences =  (new AuthRepository()).GetClients().Select(e=>e.Id.Trim().ToLower()).ToArray();
            IssuerSecurityTokenProviders = new[]
            {
                new SymmetricKeyIssuerSecurityTokenProvider(issuer, key)
            };
        }
    }
}