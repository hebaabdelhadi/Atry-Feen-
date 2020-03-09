﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;


namespace AH.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
      
        public string Name { get; set; }
        public virtual ICollection <RealArrivedTimeOfTrain> RealArrivedTimeOfTrains { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("FINALDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       

        public virtual System.Data.Entity.DbSet<Station> Stations { get; set; }
        public virtual System.Data.Entity.DbSet<Train> Trains { get; set; }
        public virtual System.Data.Entity.DbSet<TypeOfTrain> TypeOfTrains { get; set; }
        public virtual System.Data.Entity.DbSet<TrainDirection> TrainDirections { get; set; }
        public virtual System.Data.Entity.DbSet<RealArrivedTimeOfTrain> RealArrivedTimeOfTrains { get; set; }




    }
}