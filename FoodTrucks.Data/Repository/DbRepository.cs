using FoodTrucks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Data.Repository
{
    public class DbRepository
    {
        public static void AddData(List<SFDataModel> SFdata)
        {
            var FoodTrucks = MapToFoodTrucksDbDbObject(SFdata);
            using (var ctx = new FoodTrucksSFDbContext())
            {
                try
                {
                    ctx.FoodTrucksSF.AddRange(FoodTrucks);
                    ctx.SaveChanges();
                }
                catch(Exception e)
                {
                    var validationErrors = ctx.GetValidationErrors();
                }
                
            }
        }

        private static List<FoodTrucksSF> MapToFoodTrucksDbDbObject(List<SFDataModel> SFdata)
        {
            var FoodTrucks = new List<FoodTrucksSF>();

            foreach (var sfdata in SFdata)
            {
                FoodTrucks.Add(new FoodTrucksSF()
                {
                    Address = sfdata.address,
                    Applicant = sfdata.applicant,
                    Approved = sfdata.approved,
                    Block = sfdata.block,
                    Lot = sfdata.lot,
                    Blocklot = sfdata.blocklot,
                    Cnn = sfdata.cnn,
                    DaysHours = sfdata.dayshours,
                    ExpirationDate = sfdata.expirationdate,
                    FacilityType = sfdata.facilitytype,
                    FoodItems = sfdata.fooditems,
                    Latitude = sfdata.latitude,
                    Longitude = sfdata.longitude,
                    LocationDescription = sfdata.locationdescription,
                    LocationId = sfdata.objectid,
                    LocationType = sfdata.location.type,
                    Permit = sfdata.permit,
                    PriorPermit = sfdata.priorpermit,
                    Schedule = sfdata.schedule.ToString(),
                    Status = sfdata.status,
                    x = sfdata.x,
                    y = sfdata.y
                });

            }             
            return FoodTrucks;
        }
    }
}
