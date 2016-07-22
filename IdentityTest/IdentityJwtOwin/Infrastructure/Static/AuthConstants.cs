using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace IdentityJwtOwin.Infrastructure
{
    public class AuthConstants
    {
        static AuthConstants()
        {

        }
        
        public static string JWT_KEY    { get { return GetConfig("JWT_KEY"); }}
        public static string JWT_ISSUER { get { return GetConfig("JWT_ISSUER"); }}
        public static int JWT_TOKEN_EXPIRE_TIMESPAN {
            get {
                return int.Parse(GetConfig("JWT_TOKEN_EXPIRE_TIMESPAN"));
            }
        }
              

        private static string GetConfig(string key)
        {
            string r = ConfigurationManager.AppSettings[key];

            if (r == null)
            {
                throw new InvalidOperationException(String.Format("Configuração {0} não encontrada", key));
            }

            return r;
        }

    }
}