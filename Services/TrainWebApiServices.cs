using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelBookingWebApp.Models;

namespace TravelBookingWebApp.Services
{
    public class TrainWebApiServices
    {
        private static readonly HttpClient _client = new HttpClient();
        private const string BaseUrl = "https://api.irctc.com/trains";
        private const string RapidApiKey = "05eebb4b7amsh5631723653ebd60p17e438jsn7170b1054798";

        public static async Task<List<TrainListModel>> GetTrainList(string source, string destination, DateTime dateOfJourney)
        {
            var requestUri = $"{BaseUrl}/trainBetweenStations?fromStationCode={source}&toStationCode={destination}&dateOfJourney={dateOfJourney:yyyy-MM-dd}";

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Key", RapidApiKey);
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "irctc1.p.rapidapi.com");

            var response = await _client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var trainList = JsonConvert.DeserializeObject<List<TrainListModel>>(responseContent);
                return trainList;
            }
            else
            {
                // Handle unsuccessful response here
                return null;
            }
        }
    }
}
