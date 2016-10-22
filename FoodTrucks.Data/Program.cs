using FoodTrucks.Data.Models;
using FoodTrucks.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Data
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("X-App-Token", "VLAjeuRRqcKMoUS7cFdKyjHpy");
                httpClient.BaseAddress = new Uri("https://data.sfgov.org/resource/6a9r-agq8.json");

                var sfDataResponse = httpClient.GetAsync("").Result;
                sfDataResponse.EnsureSuccessStatusCode();
                var sfData = sfDataResponse.Content.ReadAsAsync<List<SFDataModel>>().Result;
                DbRepository.AddData(sfData);
                Console.WriteLine("Done");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        
    }
}
