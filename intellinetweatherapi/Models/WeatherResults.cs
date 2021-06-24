using System.Collections.Generic;

namespace intellinetweatherapi.Models
{
    public class WeatherResults
    {
        public bool ShouldGoOutside { get; set; }
        public bool ShouldSunscreen { get; set; }
        public bool CanFlyKite { get; set; }
    }
    public class WeatherStackResultset 
    {
        public WeatherStackRequest request { get; set; }
        public WeatherStackLocation location { get; set; }
        public WeatherStackCurrent current { get; set; }
    }
    public class WeatherStackRequest
    {
        public string type { get; set;}
        public string query { get; set; }
        public string language { get; set; }
        public string unit { get; set; }
    }
    public class WeatherStackLocation
    {
        public string name { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string timezone_id { get; set; }
        public string localtime { get; set; }
        public int localtime_epoch { get; set; }
        public string utc_offset { get; set; }
    }
    public class WeatherStackCurrent
    {
        public string observation_time { get; set; }
        public int temperature { get; set; }
        public int weather_code { get; set; }
        public IList<string> weather_icons { get; set; }
        public IList<string> weather_descriptions { get; set; }
        public int wind_speed { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public int pressure { get; set; }
        public decimal precip { get; set; }
        public int humidity { get; set; }
        public int cloudcover { get; set; }
        public int feelslike { get; set; }
        public int uv_index { get; set; }
        public int visibility { get; set; }
        public string is_day { get; set; }
    }
}
