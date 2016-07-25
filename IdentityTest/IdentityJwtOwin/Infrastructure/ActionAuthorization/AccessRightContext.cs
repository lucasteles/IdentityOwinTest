using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityJwtOwin.Infrastructure
{

    public class AccessRightContext : DbContext
    {
        
        public DbSet<AccessRight> AccessRights { get; set; }
        public DbSet<MyRole> MyRoles{ get; set; }

        public AccessRightContext() : base("DefaultConnection") 
        {
            // remove default initializer
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessRight>()
            .HasMany(c => c.Roles)
            .WithMany()                 
            .Map(x =>
            {
                x.MapLeftKey("AccessRightId");
                x.MapRightKey("AspNetRolesId");
                x.ToTable("AccessRightRole");
            });

            

            base.OnModelCreating(modelBuilder);
        }


    }




    

}