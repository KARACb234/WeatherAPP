using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using JsonData;
using System.Globalization;

public class WeatherUpdate
{
    public async Task<HourlyData> GetHourlyWeather(float latitude = 37.6173f, float longitude = 55.7558f)
    {
        string latitudeString  = latitude.ToString(CultureInfo.InvariantCulture);
        string longitudeString  = longitude.ToString(CultureInfo.InvariantCulture);
        string weather_url = string.Format("https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&hourly=temperature_2m", latitudeString, longitudeString);
        var networkLoader = new NetworkLoader();
        var data = await networkLoader.LoadingData(weather_url);
        WeatherData networkData = JsonConvert.DeserializeObject<WeatherData>(data);
        HourlyData hourlyData = networkData.hourly;
        return hourlyData;
    }
}
