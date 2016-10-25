using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrucksModel;
using FoodTrucksData;
using System.Device.Location;
using System.Diagnostics;

namespace FoodTrucksCore
{
    public class FoodTrucksRepository : IFoodTrucksRepository
    {
        public List<FoodTrucks> GetAllTrucks()
        {
            //using (var ctx = new FoodTrucksSFEntity())
            //{
            //    var allFoodTrucks = ctx.FoodTrucksSFs.ToList();
            //    return MapToServiceModel(allFoodTrucks);
            //}
            using (var ctx = new FoodTrucksSFEntity())
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var allFoodTrucks = ctx.Database.SqlQuery<FoodTrucksSF>("SELECT [LocationId],[Address],[DaysHours],[ExpirationDate],[FoodItems],[Latitude],[Longitude],[LocationDescription],[Schedule],[Status] FROM[dbo].[FoodTrucksSF]", new object[1]).ToList();
                stopWatch.Stop();
                Console.WriteLine(stopWatch.ElapsedMilliseconds);
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
                    //Cnn = trucks.Cnn,
                    //Approved = trucks.Approved,
                    //Block = trucks.Block,
                    //Lot = trucks.Lot,
                    //Blocklot = trucks.Blocklot,
                    //Applicant = trucks.Applicant,
                    DaysHours = trucks.DaysHours,
                    ExpirationDate = trucks.ExpirationDate,
                    //FacilityType = trucks.FacilityType,
                    FoodItems = trucks.FoodItems,
                    Latitude = (double)trucks.Latitude,
                    Longitude = (double)trucks.Longitude,
                    //LocationType = trucks.LocationType,
                    LocationDescription = trucks.LocationDescription,
                    //Permit = trucks.Permit,
                    //PriorPermit = trucks.PriorPermit,
                    Schedule = trucks.Schedule,
                    Status = trucks.Status,
                    //x = trucks.x,
                    //y = trucks.y
                });
                
            }
            return foodTrucks;
        }

        public List<FoodTrucks> GetNearbyTrucks(double latitude, double longitiude)
        {
            var allTrucks = GetAllTrucks();
            var currentCoordinates = new GeoCoordinate(latitude, longitiude);
            var nearestTrucksCoordinates = allTrucks.Select(trucks => new GeoCoordinate(trucks.Latitude ,trucks.Longitude)).Where(x => x.GetDistanceTo(currentCoordinates) < 1000.00);
            var nearestTrucks = allTrucks.Where(trucks => nearestTrucksCoordinates.Any(coordinates => trucks.Latitude == coordinates.Latitude && trucks.Longitude == coordinates.Longitude)).ToList();
            return nearestTrucks;
        }
    }
}
