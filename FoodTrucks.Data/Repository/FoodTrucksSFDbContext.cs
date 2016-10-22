﻿using FoodTrucks.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrucks.Data.Repository
{
    public partial class FoodTrucksSFDbContext : DbContext
    {
        public FoodTrucksSFDbContext() : base("name=FoodTrucksSF")
        {

        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //}
        public virtual DbSet<FoodTrucksSF> FoodTrucksSF { get; set; }
    }
}
