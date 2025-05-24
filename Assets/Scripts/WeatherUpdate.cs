using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using JsonData;
using System.Globalization;
using Assets.Scripts;

public static class WeatherUpdate
{
    public static async Task<HourlyData> GetHourlyWeather(float latitude = 37.6173f, float longitude = 55.7558f)
    {
        string latitudeString = latitude.ToString(CultureInfo.InvariantCulture);
        string longitudeString = longitude.ToString(CultureInfo.InvariantCulture);
        string weather_url = string.Format("https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&hourly=temperature_2m", latitudeString, longitudeString);
        var networkLoader = new NetworkLoader();
        var weatherData = await networkLoader.LoadingData(weather_url);
        WeatherData networkData = JsonConvert.DeserializeObject<WeatherData>(weatherData);
        HourlyData hourlyData = networkData.hourly;
        return hourlyData;
    }
    public static async Task<List<CityData>> GetCityData()
    {
        string city_url = "https://acinusproject.turgaliev.kz/city_for_forcast.json";
        var networkLoader = new NetworkLoader();
        var cityData = await networkLoader.LoadingData(city_url);
        List<CityData> networkData = JsonConvert.DeserializeObject<List<CityData>>(cityData);
        return networkData;
    } 
}
