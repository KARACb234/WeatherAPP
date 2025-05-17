using Assets.Scripts;
using JsonData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEditor;
using UnityEngine;

public class WeatherWindowUI : WindowBase
{
    [SerializeField]
    private TextMeshProUGUI _temperatureAndTimeText;
    [SerializeField]
    private TextMeshProUGUI dayText;
    [SerializeField]
    private TextMeshProUGUI editionalInformation;
    public TextMeshProUGUI GetEditionalInformation => editionalInformation;
    [SerializeField]
    private DayLoader dayLoader;
    private Dictionary<int, WeatherListOfDay> weather;
    private WorkingWithWeather workingWithWeather;
    private CityData _cityData;
    public CityData GetCityData => _cityData;
    public void Initialize(Dictionary<int, WeatherListOfDay> weather, HourlyData hourlyData)
    {
        this.weather = weather;
        workingWithWeather = new WorkingWithWeather(hourlyData);
    }
    public void UpdateDateUI(DateTime date, CityData cityData)
    {
        string text = date.ToString("dd MMMM yyyy ");
        dayText.text = text;
        _cityData = cityData;
        dayText.text += cityData.GetCountryAndCityName;
    }
    public void UpdateEditionalInformation(int day)
    {
        workingWithWeather.CalculatingTheAverageTemperatureForOneDay(day);
        workingWithWeather.FindingTheMaximumAndMinimumTemperature(day);
        workingWithWeather.CountingHoursWithPositiveAndNegativeTemperatures(day);
    }
    public void CreateButtons()
    {
        dayLoader.Initialise(weather, _cityData);
        dayLoader.onDayLoaderUpdated += ShowWeatherPerOneDay;
    }
    public void ShowWeatherPerOneDay(WeatherListOfDay weatherListOfDay)
    {
        var sb = new StringBuilder();
            foreach (var parametre in weatherListOfDay.GetWeatherParametres)
            {
                sb.Append($"{weatherListOfDay.currentDate.Day}   {parametre.time.Hour}:00, {parametre.temperature} C°\n");
            }
        _temperatureAndTimeText.text = sb.ToString();
    }
    public void ClearEditionalInformationText()
    {
        editionalInformation.text = string.Empty;
    }
}
