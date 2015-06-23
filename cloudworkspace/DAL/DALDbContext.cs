using CloudWorkSpace.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    // IdentityDbContext<ApplicationUser>
    public partial class DALDbContext : DbContext
    {
        public DALDbContext()
            : base("cloudworkspaceEntities")
        {
            //Database.SetInitializer(new DbContextInitializer());
        }

        public static DALDbContext Create()
        {
            return new DALDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
            modelBuilder.Entity<AspNetUserLogin>().HasKey(a => new { a.UserId, a.LoginProvider, a.ProviderKey });

            modelBuilder.Entity<AspNetRole>()
                .HasMany(r => r.AspNetUsers)
                .WithMany(u => u.AspNetRoles)
                .Map(r =>
                {
                    r.MapLeftKey("RoleId");
                    r.MapRightKey("UserId");
                    r.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity<ProjectTask>().ToTable("Tasks");

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Projects)
               .WithMany(p => p.Clients);
            // Also need to add field to Client Table: CreatedById ( to keep relevant people grouped ) and probably have to create some Roles.
            // Need to create Group Table
            // GroupId
            // ClientId
            // ProjectId
        }

        
        public virtual DbSet<Address> Addresses { get; set; }        
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectTask> Tasks { get; set; }        
        
    }
}
