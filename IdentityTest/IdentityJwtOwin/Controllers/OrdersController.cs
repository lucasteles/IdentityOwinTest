using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace IdentityJwtOwin.Controllers
{
    public class OrdersController : ApiController
    {
        [Authorize(Roles = "Positivador")]
        public IHttpActionResult Get()
        {
            return Ok(Order.CreateOrders());
        }

        [Authorize(Roles = "PDV")]
        public IHttpActionResult GetB()
        {           
            return Ok(Order.CreateOrders());
        }

        [DatabaseAuthorize] // teste de custom authorize atribute
        public IHttpActionResult GetC()
        {
            return Ok(Order.CreateOrders());
        }


    }



    #region Helpers

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ShipperCity { get; set; }
        public Boolean IsShipped { get; set; }

        public static List<Order> CreateOrders()
        {
            List<Order> OrderList = new List<Order>
            {
                new Order {OrderID = 10248, CustomerName = "Taiseer Joudeh", ShipperCity = "Amman", IsShipped = true },
                new Order {OrderID = 10249, CustomerName = "Ahmad Hasan", ShipperCity = "Dubai", IsShipped = false},
                new Order {OrderID = 10250,CustomerName = "Tamer Yaser", ShipperCity = "Jeddah", IsShipped = false },
                new Order {OrderID = 10251,CustomerName = "Lina Majed", ShipperCity = "Abu Dhabi", IsShipped = false},
                new Order {OrderID = 10252,CustomerName = "Yasmeen Rami", ShipperCity = "Kuwait", IsShipped = true}
            };

            return OrderList;
        }
    }

    #endregion
}




/*
 *
        #region "teste buscar dados do usuario"
        private ClaimsPrincipal TryGetOwinUser()
        {
            if (HttpContext.Current == null)
                return null;

            var context = HttpContext.Current.GetOwinContext();
            if (context == null)
                return null;

            if (context.Authentication == null || context.Authentication.User == null)
                return null;

            return context.Authentication.User;
        }
        private IList<Claim> TryGetClaim(ClaimsPrincipal owinUser, string key)
        {
            if (owinUser == null)
                return null;

            if (owinUser.Claims == null)
                return null;

            return owinUser.Claims.Where(o => o.Type.Equals(key)).ToList();
        }
        #endregion
*/