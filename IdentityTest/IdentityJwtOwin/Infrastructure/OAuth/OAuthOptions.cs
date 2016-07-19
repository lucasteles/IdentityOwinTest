using IdentityJwtOwin.Infrastructure.Refresh_Token;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;


namespace IdentityJwtOwin.Infrastructure
{
    public class OAuthOptions : OAuthAuthorizationServerOptions
    {
        public OAuthOptions()
        {
            AllowInsecureHttp = true;
            TokenEndpointPath = new PathString("/token");
            AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60);
            AccessTokenFormat = new JwtFormat(this);
            Provider = new OAuthProvider();
            RefreshTokenProvider = new SimpleRefreshTokenProvider();
            
        }
    }
}