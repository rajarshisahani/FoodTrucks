
using FoodTrucksModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucksCore
{
    public interface IFoodTrucksRepository
    {
        List<FoodTrucks> GetNearbyTrucks(double latitude, double longitiude);

        List<FoodTrucks> GetAllTrucks();
    }
}
