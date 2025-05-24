using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityData
{
    [JsonProperty("country")]
    private string _countryName;
    public string GetCountryName => _countryName;
    [JsonProperty("city")]
    private string _cityName;
    public string CityName => _cityName;
    [JsonProperty("latitude")]
    private float _latitude;
    public float Latitude => _latitude;
    [JsonProperty("longitude")]
    private float _longitude;
    public float Longitude => _longitude;
    [JsonConstructor]
    public CityData(string countryName, string cityName, float latitude, float longitude)
    {
        _countryName = countryName;
        _cityName = cityName;
        _latitude = latitude;
        _longitude = longitude;
    }
}
