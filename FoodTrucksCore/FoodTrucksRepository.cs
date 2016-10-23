using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrucksModel;
using FoodTrucksData;

namespace FoodTrucksCore
{
    public class FoodTrucksRepository : IFoodTrucksRepository
    {
        public List<FoodTrucks> GetAllTrucks()
        {
            using (var ctx = new FoodTrucksEntity())
            {
                var allFoodTrucks = ctx.FoodTrucksSFs.ToList();
                return MapToServiceModel(allFoodTrucks);
            }
        }

        private List<FoodTrucks> MapToServiceModel(List<FoodTrucksSF> allFoodTrucks)
        {
            List<FoodTrucks> foodTrucks = new List<FoodTrucks>();
            foreach(var trucks in allFoodTrucks)
            {
                foodTrucks.Add(new FoodTrucks()
                {
                    LocationId = trucks.LocationId,


                    Address = trucks.Address,


                    Cnn = trucks.Cnn,

                    Approved = trucks.Approved,


                    Block = trucks.Block,


                    Lot = trucks.Lot,


                    Blocklot = trucks.Blocklot,


                    Applicant = trucks.Applicant,


                    DaysHours = trucks.DaysHours,

                    ExpirationDate = trucks.ExpirationDate,


                    FacilityType = trucks.FacilityType,


                    FoodItems = trucks.FoodItems,


                    Latitude = trucks.Latitude,


                    Longitude = trucks.Longitude,


                    LocationType = trucks.LocationType,


                    LocationDescription = trucks.LocationDescription,


                    Permit = trucks.Permit,


                    PriorPermit = trucks.PriorPermit,


                    Schedule = trucks.Schedule,


                    Status = trucks.Status,


                    x = trucks.x,


                    y = trucks.y

                });
                
            }
            return foodTrucks;
        }

        public List<FoodTrucks> GetNearbyTrucks(string latitude, string longitiude)
        {
            throw new NotImplementedException();
        }
    }
}
