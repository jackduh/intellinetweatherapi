using intellinetweatherapi.Interfaces;

namespace intellinetweatherapi
{
    class ConsoleApp
    {
        private readonly IWeather _weather;
        public ConsoleApp(IWeather weather)
        {
            _weather = weather;
        }

        public void Run()
        {
            _weather.RunWeatherConsoleApp();
        }
    }
}
