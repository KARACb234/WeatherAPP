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
    private const string KEY = "6b6ed7ce57d546358c5112427251007";
    public static async Task<WeatherInfo> GetHourlyWeather(float latitude = 37.6173f, float longitude = 55.7558f, int days = 1, string lang = "ru")
    {
        string latitudeString = latitude.ToString(CultureInfo.InvariantCulture);
        string longitudeString = longitude.ToString(CultureInfo.InvariantCulture);
        string weather_url = string.Format("http://api.weatherapi.com/v1/forecast.json?key={0}&q={1},{2}&days={3}&lang={4}", KEY, latitudeString, longitudeString, days, lang);
        var networkLoader = new NetworkLoader();
        var weatherInfoJson = await networkLoader.LoadingData(weather_url);
        WeatherInfo weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(weatherInfoJson);
        return weatherInfo;
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
