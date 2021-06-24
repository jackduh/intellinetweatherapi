using System;
using System.Net.Http;
using intellinetweatherapi.Interfaces;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace intellinetweatherapi.Implementations
{
    public class Weather : IWeather
    {
        private static readonly HttpClient HttpClient;
        static Weather()
        {
            HttpClient = new HttpClient();
        }
        public void RunWeatherConsoleApp()
        {
            Console.WriteLine("What is your zipcode?");
            string zipcode = Console.ReadLine();
            try
            {
                Task<Models.WeatherResults> task = Task.Run<Models.WeatherResults>(async () => await GetWeatherResults(zipcode));                
                PrintOutput(task.Result);
            } catch
            {
                Console.WriteLine("Something went wrong, zipcode correct?");
            }
            
        }
        private async Task<Models.WeatherResults> GetWeatherResults(string zipcode)
        {
            HttpResponseMessage response = await HttpClient.GetAsync($"http://api.weatherstack.com/current?access_key=610acf4c1d203448cd6f671955c5e8aa&query={zipcode}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Models.WeatherStackResultset>(responseBody);
            return new Models.WeatherResults
            {
                ShouldGoOutside = !result.current.weather_descriptions.Any(s => s.Equals("Rain", StringComparison.OrdinalIgnoreCase)),
                ShouldSunscreen = result.current.uv_index > 3 ? true : false,
                CanFlyKite = (!result.current.weather_descriptions.Any(s => s.Equals("Rain", StringComparison.OrdinalIgnoreCase)) && result.current.wind_speed > 15 ) ? true : false
            };
        }
        private void PrintOutput(Models.WeatherResults weatherResults)
        {
            Console.WriteLine($"Should I go outside? {weatherResults.ShouldGoOutside.ToString()}");
            Console.WriteLine($"Should I wear sunscreen? {weatherResults.ShouldSunscreen.ToString()}");
            Console.WriteLine($"Can I fly my kite? {weatherResults.CanFlyKite.ToString()}");
        }
    }
}
