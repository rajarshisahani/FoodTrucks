using FoodTrucksWebJob.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrucksWebJob.Repository
{
    public partial class FoodTrucksSFDbContext : DbContext
    {
        public FoodTrucksSFDbContext() : base("name=FoodTrucksSF")
        {

        }
        
        public virtual DbSet<FoodTrucksSF> FoodTrucksSF { get; set; }
    }
}
