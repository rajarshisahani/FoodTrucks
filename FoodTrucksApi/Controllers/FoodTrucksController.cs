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
        
        public FoodTrucksController()
        {

        }
        
        [HttpGet]
        public HttpResponseMessage GetNearbyTrucks([FromUri]string latitude, [FromUri]string longitude)
        {
            var getTrucks = new List<string>();
            var response = Request.CreateResponse(HttpStatusCode.OK, getTrucks);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetTrucks()
        {
            var getTrucks = new List<string>();
            var response = Request.CreateResponse(HttpStatusCode.OK, getTrucks);
            return response;
        }

    }
}
