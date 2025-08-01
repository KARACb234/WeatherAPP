using JsonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            WorkingWithWeather workingWithWeather = new WorkingWithWeather(weatherInfo.forecast);
            workingWithWeather.OpenWindow(cityData);
            WindowManager.Instance.HideWindow<LoadingWindow>();
        }

        public void OpenWindow(CityData cityData) 
        {
            WeatherLoading(cityData);
        }
    }
}
