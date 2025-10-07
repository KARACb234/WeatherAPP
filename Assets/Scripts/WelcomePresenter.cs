using JsonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class WelcomePresenter
    {
        private readonly WorkingWithWeather weather;
        private WelcomeWindow welcomeWindowUI;
        private const int DAYCOUNT = 3;

        private async void WeatherLoading(CityData cityData)
        {
            WindowManager.Instance.Show<LoadingWindow>();

            WeatherInfo weatherInfo =  await WeatherUpdate.GetHourlyWeather(cityData.Latitude, cityData.Longitude, DAYCOUNT);
            WeatherConfig.current  = weatherInfo.current;
            WeatherConfig.forecast  = weatherInfo.forecast;
            WeatherConfig.location = weatherInfo.location;
            WeatherConfig.Initialised = true;
            WorkingWithWeather workingWithWeather = new WorkingWithWeather();
            workingWithWeather.OpenWindow();
            WindowManager.Instance.HideWindow<LoadingWindow>();
        }

        public void OpenWindow(CityData cityData) 
        {
            WeatherLoading(cityData);
        }
    }
}
