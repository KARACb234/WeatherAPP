using Assets.Scripts;
using JsonData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
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
    public void Initialize(Dictionary<int, WeatherListOfDay> weather, HourlyData hourlyData)
    {
        this.weather = weather;
        workingWithWeather = new WorkingWithWeather(hourlyData);
    }
    public void UpdateDateUI(DateTime date)
    {
        string text = date.ToString("dd MMMM yyyy");
        dayText.text = text;
    }
    public void UpdateEditionalInformation(int day)
    {
        workingWithWeather.CalculatingTheAverageTemperatureForOneDay(day);
        workingWithWeather.FindingTheMaximumAndMinimumTemperature(day);
        workingWithWeather.CountingHoursWithPositiveAndNegativeTemperatures(day);
    }
    public void CreateButtons()
    {
        dayLoader.Initialise(weather);
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
}
