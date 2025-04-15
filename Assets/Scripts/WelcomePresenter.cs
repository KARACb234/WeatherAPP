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
        private readonly WeatherUpdate weatherUpdate = new WeatherUpdate();
        private readonly WorkingWithWeather weather;
        private WelcomeWindow welcomeWindowUI;

        private async void WeatherLoading(float latitude, float longitude)
        {
            WindowManager.Instance.Show<LoadingWindow>();
            HourlyData hourlyData =  await weatherUpdate.GetHourlyWeather(latitude, longitude);
            WorkingWithWeather workingWithWeather = new WorkingWithWeather(hourlyData);
            workingWithWeather.OpenWindow();
            WindowManager.Instance.HideWindow<LoadingWindow>();
        }

        public void OpenWindow(float latitude, float longitude) 
        {
            WeatherLoading(latitude, longitude);
        }

        public void Dispose()
        {
// welcomeWindowUI.onWeatherButtonClicked -= WeatherLoading;
        }
    }
}
