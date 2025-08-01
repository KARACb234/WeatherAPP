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
    private readonly Dictionary<ForecastDayData, WeatherListOfDay> weatherDays = new ();
    private WeatherWindowUI windowUI;
    private WorkingWithWeather workingWithWeather;
    private ForecastData _forecastData;
    private CityData selectedCityData;

    public WorkingWithWeather(ForecastData forecastData)
    {
        for (int i = 0; i < forecastData.forecastday.Length; i++)
        {
            CreateTemperatureAndTime(forecastData.forecastday[i]);
        }
        _forecastData = forecastData;
    }
    public void ActualizeUi(WeatherListOfDay weatherListOfDay, ForecastDayData day)
    {
        CheckWindow();
        windowUI.UpdateDateUI(weatherListOfDay.currentDate, selectedCityData);
        windowUI.ShowWeatherPerOneDay(weatherListOfDay);
        CalculatingTheAverageTemperatureForOneDay(day);
        FindingTheMaximumAndMinimumTemperature(day);
        CountingHoursWithPositiveAndNegativeTemperatures(day);
        windowUI.CreateButtons();
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
    public void CalculatingTheAverageTemperatureForOneDay(ForecastDayData day)
    {
        CheckWindow();
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
            string averageTemperatureText = $"Средняя температура за {day.date.Day} число: {averageTemperature} \n";
            windowUI.GetEditionalInformation.text += averageTemperatureText;
    }

    public void FindingTheMaximumAndMinimumTemperature(ForecastDayData day)
    {
        CheckWindow();
        List<float> listOfTemperatures = new List<float>();
        if (weatherDays.TryGetValue(day, out var weather))
        {
            foreach (var parametre in weather.GetWeatherParametres)
            {
                listOfTemperatures.Add(parametre.temperature);
            }
        }
        listOfTemperatures.Sort();
        string maximumAndMinimumTemperatureText = $"Максимальная температура: {listOfTemperatures[0]}, минимальная температур: {listOfTemperatures[^1]} \n";
        windowUI.GetEditionalInformation.text += maximumAndMinimumTemperatureText;
    }
    public void CountingHoursWithPositiveAndNegativeTemperatures(ForecastDayData day)
    {
        CheckWindow();
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
        windowUI.GetEditionalInformation.text += $"часы с температурой ниже 0: {HoursWithMinusTemperature}, часы с температурой выше 0: {HoursWithPlusTemperature}";
    }

    public void OpenWindow(CityData cityData)
    {
        for (int i = 0; i < weatherDays.Count; i++)
        {
            selectedCityData = cityData;
            windowUI = WindowManager.Instance.Show<WeatherWindowUI>() as WeatherWindowUI;
            windowUI.Initialize(weatherDays, _forecastData);
            WeatherListOfDay weather = weatherDays[_forecastData.forecastday[i]];
            ActualizeUi(weather, _forecastData.forecastday[i]);
        }
    }
    private void CheckWindow()
    {
        if (windowUI == null)
        {
            if (WindowManager.Instance.TryGetOpenWindow<WeatherWindowUI>(out var window))
            {
                windowUI = window as WeatherWindowUI;
            }
        }
    }
}