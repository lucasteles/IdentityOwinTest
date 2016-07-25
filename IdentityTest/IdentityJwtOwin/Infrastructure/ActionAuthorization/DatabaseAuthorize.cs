
using IdentityJwtOwin.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Http.Controllers;

namespace IdentityJwtOwin
{
    public class DatabaseAuthorize : System.Web.Http.AuthorizeAttribute
    {

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            // hamdle the request
            base.HandleUnauthorizedRequest(actionContext);
        }
           

      
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var incomingPrincipal = actionContext.RequestContext.Principal;
            
            if (incomingPrincipal.Identity.IsAuthenticated)
            {
                var controllerName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                var actionName = actionContext.ActionDescriptor.ActionName;

                var user = (ClaimsIdentity)incomingPrincipal.Identity;
                var userRoles = user.Claims.Where(o => o.Type.Equals(user.RoleClaimType))
                                .Select(e => e.Value.ToLower().Trim()).ToList();

                // validar controler e action por role.
                // pode buscar no banco

                using (var repo = new AccessRightRepository())
                {
                    var roles = repo.GetRolesFromAction(controllerName, actionName);

                    if (roles == null)
                        return false;

                    foreach (var item in userRoles)
                    {
                        if (roles.Contains(item))
                            return true;

                    }

                }
            }
            
            return false;
        }



    }
}
