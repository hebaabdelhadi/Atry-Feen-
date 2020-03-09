using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TrainsFinal.Models
{
    public  class TrainContext : DbContext
    {
        public TrainContext()
            : base("name=TrainsEntities")
        {
        }

        
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<RealArrivedTimeOfTrain> RealArrivedTimeOfTrains { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Train> Trains { get; set; }
        public virtual DbSet<TrainDirection> TrainDirections { get; set; }
        public virtual DbSet<TypeOfTrain> TypeOfTrains { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

         /*   modelBuilder
                .Conventions
                .Remove<OneToManyCascadeDeleteConvention>();*/
        }
    }

}