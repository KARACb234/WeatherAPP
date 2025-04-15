using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class WeatherListOfDay
    {
        private List<WeatherParametres> weatherParametres = new List<WeatherParametres>();
        public IReadOnlyList<WeatherParametres> GetWeatherParametres => weatherParametres;
        public readonly DateTime currentDate;

        public WeatherListOfDay(DateTime currentDate)
        {
            this.currentDate = currentDate;
        }

        public void AddWeather(DateTime time, float temperature)
        {
            WeatherParametres weatherParameter = new WeatherParametres(time, temperature);
            weatherParametres.Add(weatherParameter);
        }
    }
    public class WeatherParametres
    {
        public readonly DateTime time;
        public readonly float temperature;
        public WeatherParametres(DateTime time, float temperature)
        {
            this.time = time;
            this.temperature = temperature;
        }

    }
}
