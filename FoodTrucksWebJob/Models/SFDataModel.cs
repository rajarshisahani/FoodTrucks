﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucksWebJob.Models
{
    public class SFDataModel
    {
        public string address;
        public string applicant;
        public DateTime approved;//RoundTrip
        public string block;
        public string blocklot;
        public string cnn;
        public string dayshours;
        public DateTime expirationdate;
        public string facilitytype;
        public string fooditems;
        public double latitude;
        public Location location;
        public string locationdescription;
        public double longitude;
        public string lot;
        public int objectid;
        public string permit;
        public string priorpermit;
        public string received;
        public Uri schedule;
        public string status;
        public string x;
        public string y;


        public class Location
        {
            public string type;
            public List<string> coordinates;
        }
    }
}
