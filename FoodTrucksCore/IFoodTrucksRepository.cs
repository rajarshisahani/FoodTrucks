
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
        List<FoodTrucks> GetNearbyTrucks(string latitude, string longitiude);

        List<FoodTrucks> GetAllTrucks();
    }
}
