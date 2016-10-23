using FoodTrucksCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FoodTrucksApi.Controllers
{

    public class FoodTrucksController : ApiController
    {
        private IFoodTrucksRepository _foodTrucksRepository;
        
        public FoodTrucksController(IFoodTrucksRepository foodTrucksRepository)
        {
            _foodTrucksRepository = foodTrucksRepository;
        }
        
        [HttpGet]
        public HttpResponseMessage GetNearbyTrucks([FromUri]double latitude, [FromUri]double longitude)
        {
            HttpResponseMessage response;
            try
            {
                var trucks = _foodTrucksRepository.GetNearbyTrucks(latitude, longitude);
                if (!trucks.Any())
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No data found for the corresponding request");
                }
                response = Request.CreateResponse(HttpStatusCode.OK, trucks);
                //return response;
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Partner downstream system failed to respond. Please check later.");
                //return response;
            }
            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetTrucks()
        {
            HttpResponseMessage response;
            try
            {
                var trucks = _foodTrucksRepository.GetAllTrucks();
                if(!trucks.Any())
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "No data found for the corresponding request");
                }
                response = Request.CreateResponse(HttpStatusCode.OK, trucks);
                //return response;
            }
            catch(Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Partner downstream system failed to respond. Please check later.");
                //return response;
            }
            return response;
        }

    }
}
