using FoodTrucks.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using FoodTrucks.Contract;
using System.Net.Http;
using Newtonsoft.Json;

namespace FoodTrucks.Controllers
{
    public class HomeController : Controller
    {
        List<FoodTruck> _foodTruckCache = new List<FoodTruck>();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("GetFoodTrucks")]
        public ActionResult GetFoodTrucks()
        {
            var foodtrucks = gettrucks("http://foodtruckssfapi.azurewebsites.net/api/foodtrucks");
            _foodTruckCache = foodtrucks;
            return Json(foodtrucks, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("RefreshFoodTrucks")]
        public ActionResult RefreshFoodTrucks()
        {
            var foodtrucks = gettrucks("http://foodtruckssfapi.azurewebsites.net/api/foodtrucks");
            _foodTruckCache = foodtrucks;
            return Json(foodtrucks, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getfoodtrucksbyaddress(string address)
        {
            var locobj = new AddressSearchResult();
            var foodtrucks = new List<FoodTruck>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=AIzaSyCuhHOGscxhk2qVmxdB0KPY6bnBMxbD9Mw");
                var response = httpClient.GetAsync("").Result;
                locobj = response.Content.ReadAsAsync<AddressSearchResult> ().Result;
                
            }

            if(locobj!= null && locobj.results != null && locobj.results.Count() > 0)
                {
                var location = locobj.results[0].geometry.location;
                foodtrucks = gettrucks("http://foodtruckssfapi.azurewebsites.net/api/foodtrucks?latitude=" + location.lat + "&longitude=" + location.lng);
            }

            return Json(foodtrucks, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("SearchFoodTrucks")]
        public ActionResult SearchFoodTrucks(string locationString)
        {
            var locationObject = JsonConvert.DeserializeObject<TruckLocation>(locationString);            
            var foodtrucks = gettrucks("http://foodtruckssfapi.azurewebsites.net/api/foodtrucks?latitude=" + locationObject.Latitude + "&longitude=" + locationObject.Longitude);            
            return Json(foodtrucks, JsonRequestBehavior.AllowGet);
        }

        public List<FoodTruck> gettrucks(string uri)
        {
            List<FoodTruck> foodtrucks = new List<FoodTruck>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(uri);
                httpClient.DefaultRequestHeaders.Add("authorization", "iamauthorized");
                var response = httpClient.GetAsync("").Result;
                var foodTruckResponse = response.Content.ReadAsAsync<List<FoodTruck>>().Result;
                foodtrucks = foodTruckResponse;
            }

            return foodtrucks;

        }
    }
}