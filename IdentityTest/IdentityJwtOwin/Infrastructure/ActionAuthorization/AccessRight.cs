using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityJwtOwin.Infrastructure
{
    [Table("AccessRight")]
    public class AccessRight
    {
        [Key]
        public int Id { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }
        
        
        public virtual IList<MyRole> Roles { get; set; }
    }

    [Table("AspNetRoles")]
    public class MyRole 
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }


    }

    /*
    [Table("AccessRightRole")]
    public class AccessRightRole
    {
        [Key]
        public int Id { get; set; }

        public int IdAccessRight { get; set; }
        public AccessRight AccessRight { get; set; }

        public int IdRole { get; set; }
        public IdentityRole AccessRole { get; set; }



    }*/

}