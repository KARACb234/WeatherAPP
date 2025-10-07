using JsonData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.HoursElement
{
    public class HourElementsController
    {
        private Dictionary<DateTime, HourData[]> forecastDayData = new Dictionary<DateTime, HourData[]>();
        private HourElement _hourElement;
        private Transform _contentTransform;
        private HourElementCreator _hourElementCreator;
        public HourElementsController(Transform contentTransform,  HourElementCreator hourElementCreator)
        {
            _hourElementCreator = hourElementCreator;
            _contentTransform = contentTransform;
            var forecast = WeatherConfig.forecast.forecastday;
            foreach (var day in forecast)
            {
                forecastDayData.Add(day.date, day.hour);
            }
            hourElementCreator.ClearHourElemetScrol(contentTransform);
            CreateAllHourElements();
        }

        private void CreateAllHourElements()
        {
            DateTime localTime = new DateTime(WeatherConfig.location.localtime.Year, WeatherConfig.location.localtime.Month, 
                WeatherConfig.location.localtime.Day, 0,  0, 0);
            foreach (var hour in forecastDayData[localTime])
            {
                _hourElement = new HourElement(hour.time, hour.temp_c, hour.condition.icon);
                HourElementUI hourElementUi = _hourElementCreator.CreateHourElementUI(_contentTransform);
                hourElementUi.CreateUI(_hourElement.TimeText.ToString("HH:mm"), _hourElement.Temperature,
                    _hourElement.ImageURL);
            }
        }
    }
}