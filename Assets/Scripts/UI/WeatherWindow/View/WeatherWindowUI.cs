using Assets.Scripts;
using JsonData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEditor;
using UnityEngine;

public class WeatherWindowUI : WindowBase
{
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
    [SerializeField]
    private WeatherElement _weatherElement;
    [SerializeField]
    private Transform controlerTransform;
    private Dictionary<string, int> possibleTimeOfDay = new Dictionary<string, int>()
    {
        { "Утро", 7 },
        { "День", 14},
        { "Вечер", 19},
        { "Ночь", 2 }
    };
    private List<WeatherElement> _weatherElements = new List<WeatherElement>();
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
        //dayText.text += cityData.GetCountryAndCityName;
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
        ClearMainInformation();
        foreach (var (dayTime, time) in possibleTimeOfDay)
        {
            WeatherElement weatherElement = Instantiate(_weatherElement, controlerTransform);
            _weatherElement.TimeOfDay.text = dayTime;
            _weatherElement.Temperature.text = weatherListOfDay.GetWeatherParametres[time].temperature.ToString();
            _weatherElements.Add(weatherElement);
        }
        //var sb = new StringBuilder();
        //Debug.Log(1);
        //foreach (var parametre in weatherListOfDay.GetWeatherParametres)
        //{
        //    sb.Append($"{weatherListOfDay.currentDate.Day}   {parametre.time.Hour}:00, {parametre.temperature} C°\n");
        //}
        //_temperatureAndTimeText.text = sb.ToString();
        //Debug.Log(_temperatureAndTimeText);
    }
    public void ClearEditionalInformationText()
    {
        editionalInformation.text = string.Empty;
    }
    public void ClearMainInformation()
    {
        foreach(var weatherElement in _weatherElements)
        {
            Destroy(weatherElement.gameObject);
        }
        _weatherElements.Clear();
    }
}
