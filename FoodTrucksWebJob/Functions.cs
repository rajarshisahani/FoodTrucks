using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Timers;
using System.Net.Http;
using FoodTrucksWebJob.Models;
using FoodTrucksWebJob.Repository;

namespace FoodTrucksWebJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([TimerTrigger("00:15:00", RunOnStartup = true)] TimerInfo timerInfo, TextWriter log)
        {
            try
            {
                string cachedContent = null;
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("X-App-Token", "VLAjeuRRqcKMoUS7cFdKyjHpy");
                httpClient.BaseAddress = new Uri("https://data.sfgov.org/resource/6a9r-agq8.json");

                var sfDataResponse = httpClient.GetAsync("").Result;
                sfDataResponse.EnsureSuccessStatusCode();
                var sfhashContent = sfDataResponse.Content.ReadAsStringAsync().Result;
                if (string.Compare(sfhashContent,cachedContent) == 0)
                {
                    var sfData = sfDataResponse.Content.ReadAsAsync<List<SFDataModel>>().Result;
                    DbRepository.AddData(sfData);
                    Console.WriteLine("Done");
                    Console.ReadKey();
                    cachedContent = sfhashContent;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
