using Assets.Scripts;
using JsonData;
using System;
using System.Collections.Generic;
using UnityEngine;

public class WorkingWithWeather
{
    private readonly Dictionary<ForecastDayData, WeatherListOfDay> weatherDays = new ();
    private WeatherWindowUI windowUI;

    public WorkingWithWeather()
    {
        for (int i = 0; i < WeatherConfig.forecast.forecastday.Length; i++)
        {
            CreateTemperatureAndTime(WeatherConfig.forecast.forecastday[i]);
        }
    }

    public void CreateTemperatureAndTime(ForecastDayData forecastDayData)
    {
        for (int i = 0; i < forecastDayData.hour.Length; i++)
        {
                if (weatherDays.ContainsKey(forecastDayData))
                {
                    if (weatherDays.TryGetValue(forecastDayData, out var weather))
                    {
                    weather.AddWeather(forecastDayData.hour[i].time, forecastDayData.hour[i].temp_c);
                    }
                }
                else
                {
                    WeatherListOfDay weather = new WeatherListOfDay(forecastDayData.date);
                    weatherDays.Add(forecastDayData, weather);
                }
            
        }
    }
    public void OpenWindow()
    {
        windowUI = WindowManager.Instance.Show<WeatherWindowUI>() as WeatherWindowUI;
        windowUI.Initialize();
    }
}