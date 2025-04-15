using Assets.Scripts;
using JsonData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using TMPro;
using UnityEngine;

public class WorkingWithWeather
{
    private readonly Dictionary<int, WeatherListOfDay> weatherDays = new Dictionary<int, WeatherListOfDay>();
    private WeatherWindowUI windowUI;
    private WorkingWithWeather workingWithWeather;
    private HourlyData _hourlyData;

    public WorkingWithWeather(HourlyData hourlyData)
    {
        CreateTemperatureAndTime(hourlyData);
        _hourlyData = hourlyData;
    }
    public void ActualizeUi(WeatherListOfDay weatherListOfDay, int day)
    {
        windowUI.UpdateDateUI(weatherListOfDay.currentDate);
        windowUI.ShowWeatherPerOneDay(weatherListOfDay);
        CalculatingTheAverageTemperatureForOneDay(day);
        FindingTheMaximumAndMinimumTemperature(day);
        CountingHoursWithPositiveAndNegativeTemperatures(day);
        windowUI.CreateButtons();
    }

    public void CreateTemperatureAndTime(HourlyData hourlyData)
    {
        for (int i = 0; i < hourlyData.temperature_2m.Length; i++)
        {
            if (DateTime.TryParse(hourlyData.time[i], out var result))
            {
                Debug.Log(result.ToString());
                if (weatherDays.ContainsKey(result.Date.Day))
                {
                    if (weatherDays.TryGetValue(result.Date.Day, out var weather))
                    {
                        weather.AddWeather(result, hourlyData.temperature_2m[i]);
                    }
                }
                else
                {
                    WeatherListOfDay weather = new WeatherListOfDay(result.Date);
                    weatherDays.Add(result.Date.Day, weather);
                }
            }
        }
    }
    public void CalculatingTheAverageTemperatureForOneDay(int day)
    {
            List<float> listOfTemperatures = new List<float>();
            double averageTemperature = 0;
            if (weatherDays.TryGetValue(day, out var weather))
            {
                foreach (var parametre in weather.GetWeatherParametres)
                {
                    listOfTemperatures.Add(parametre.temperature);
                    averageTemperature += parametre.temperature;
                }
            }
            averageTemperature = averageTemperature / listOfTemperatures.Count;
            averageTemperature = Math.Round(averageTemperature, 1);
            string averageTemperatureText = $"Средняя темперетура за {day} число: {averageTemperature}\n";
            GetWeatherWindowUI().GetEditionalInformation.text += averageTemperatureText;
    }

    public void FindingTheMaximumAndMinimumTemperature(int day)
    {
        List<float> listOfTemperatures = new List<float>();
        if (weatherDays.TryGetValue(day, out var weather))
        {
            foreach (var parametre in weather.GetWeatherParametres)
            {
                listOfTemperatures.Add(parametre.temperature);
            }
        }
        listOfTemperatures.Sort();
        string maximumAndMinimumTemperatureText = $"Минимальная температура: {listOfTemperatures[0]}, максимальная температура: {listOfTemperatures[^1]}\n";
        GetWeatherWindowUI().GetEditionalInformation.text += maximumAndMinimumTemperatureText;
    }
    public void CountingHoursWithPositiveAndNegativeTemperatures(int day)
    {
        int HoursWithMinusTemperature = 0;
        int HoursWithPlusTemperature = 0;
        if (weatherDays.TryGetValue(day, out var weather))
        {
            foreach (var parametre in weather.GetWeatherParametres)
            {
                if (parametre.temperature < 0)
                {
                    HoursWithMinusTemperature++;
                }
                else
                {
                    HoursWithPlusTemperature++;
                }
            }
        }

        GetWeatherWindowUI().GetEditionalInformation.text += $"Часы с температурой ниже 0: {HoursWithMinusTemperature}, Часы с температурой 0 и выше: {HoursWithPlusTemperature}";
    }

    public void OpenWindow()
    {
        windowUI = WindowManager.Instance.Show<WeatherWindowUI>() as WeatherWindowUI;
        Debug.Log(windowUI == null);
        windowUI.Initialize(weatherDays, _hourlyData);
        int firstDay = weatherDays.First().Key;
        WeatherListOfDay weather = weatherDays[firstDay];
        ActualizeUi(weather, firstDay);
    }
    private WeatherWindowUI GetWeatherWindowUI()
    {
        if (windowUI == null)
        {
            Debug.Log(WindowManager.Instance.TryGetOpenWindow<WeatherWindowUI>(out WindowBase w));
            if (WindowManager.Instance.TryGetOpenWindow<WeatherWindowUI>(out WindowBase window))
            {
                windowUI = window as WeatherWindowUI;
            }
        }
        return windowUI;
    }
}