using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build;
using UnityEngine;

public class DayLoader : MonoBehaviour
{
    [SerializeField]
    private DaySelectorElement _butonPrefab;
    private Dictionary<int, WeatherListOfDay> weatherDays;
    [SerializeField]
    private Transform dayLoaderTransform;
    public event Action<WeatherListOfDay> onDayLoaderUpdated = delegate { };
    [SerializeField]
    private WeatherWindowUI weatherWindowUI;
    private DaySelectorElement[] daySelectorElements;
    private CityData _cityData;
    public void Initialise(Dictionary<int, WeatherListOfDay> weather, CityData cityData)
    {
        weatherDays = weather;
        _cityData = cityData;
        LoadDate();
    }

    public void LoadDate()
    {
        daySelectorElements = new DaySelectorElement[weatherDays.Count];
        int i = 0;
        foreach (var day in weatherDays.Values)
        {
            {
                DaySelectorElement element = Instantiate(_butonPrefab, dayLoaderTransform);
                element.Initialisation(day.currentDate, i);
                element.onButtonClicked += OnDayLoaderUpdated;
                element.onButtonClicked += OnSelectButon;
                element.onButtonClicked += OnWeatherUiUpdated;
                daySelectorElements[i] = element;
                i++;
            }
        }
    }
       private void OnSelectButon(DayButonInfo dayButonInfo)
        {
            foreach (var day in daySelectorElements)
            {
                day.GetButton.interactable = true;
            }
            daySelectorElements[dayButonInfo.GetButonIndex].GetButton.interactable = false;
        }

        private void OnDayLoaderUpdated(DayButonInfo dayButonInfo)
        {
            var day = weatherDays[dayButonInfo.GetDate.Day];
            if (day == null)
            {
                throw new Exception("День введён не корректно");
            }
            onDayLoaderUpdated.Invoke(day);
        }
    private void OnWeatherUiUpdated(DayButonInfo dayButonInfo)
    {
        weatherWindowUI.ClearEditionalInformationText();
        weatherWindowUI.UpdateDateUI(dayButonInfo.GetDate, _cityData);
        weatherWindowUI.UpdateEditionalInformation(dayButonInfo.GetDate.Day);
    }
    
}
