using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityJwtOwin.Infrastructure

{
    public class AccessRightRepository : IDisposable
    {
        private AccessRightContext _ctx;

        public AccessRightRepository()
        {
            _ctx = new AccessRightContext();
        }

        public IList<string> GetRolesFromAction(string controller, string action)
        {


            var ar = _ctx.AccessRights
                .Include("Roles")
                .Where(e => e.Action.Equals(action) && e.Controller.Equals(controller))
                .ToList();
                

                if (ar == null || ar.Count()==0)
                    return null;

                var ret = ar.FirstOrDefault().Roles.Select(e=>e.Name.ToLower().Trim()).ToList();
                return ret;  

        }



        public void Dispose()
        {
            _ctx.Dispose();
        }


        }
    }