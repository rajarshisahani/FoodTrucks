namespace FoodTrucksData
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FoodTrucksSFEntity : DbContext
    {
        public FoodTrucksSFEntity()
            : base("name=FoodTrucksEntity")
        {
        }

        public virtual DbSet<FoodTrucksSF> FoodTrucksSFs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.Cnn)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.Block)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.Lot)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.Blocklot)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.Applicant)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.DaysHours)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.FacilityType)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.FoodItems)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.LocationType)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.LocationDescription)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.Permit)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.PriorPermit)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.Schedule)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.x)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTrucksSF>()
                .Property(e => e.y)
                .IsUnicode(false);
        }
    }
}
