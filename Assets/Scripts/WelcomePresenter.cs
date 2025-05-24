using JsonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class WelcomePresenter : IDisposable
    {
        private readonly WorkingWithWeather weather;
        private WelcomeWindow welcomeWindowUI;

        private async void WeatherLoading(CityData cityData)
        {
            WindowManager.Instance.Show<LoadingWindow>();

            HourlyData hourlyData =  await WeatherUpdate.GetHourlyWeather(cityData.Latitude, cityData.Longitude);
            WorkingWithWeather workingWithWeather = new WorkingWithWeather(hourlyData);
            workingWithWeather.OpenWindow(cityData);
            WindowManager.Instance.HideWindow<LoadingWindow>();
        }

        public void OpenWindow(CityData cityData) 
        {
            WeatherLoading(cityData);
        }

        public void Dispose()
        {
// welcomeWindowUI.onWeatherButtonClicked -= WeatherLoading;
        }
    }
}
