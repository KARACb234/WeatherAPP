using Assets.Scripts;
using System;
using System.Collections.Generic;
using JsonData;
using UnityEngine;

public class DayLoader : MonoBehaviour
{
    [SerializeField]
    private DaySelectorElement _butonPrefab;
    private Dictionary< ForecastDayData, WeatherListOfDay> weatherDays;
    [SerializeField]
    private Transform dayLoaderTransform;
    public event Action<WeatherListOfDay> onDayLoaderUpdated = delegate { };
    [SerializeField]
    private WeatherWindowUI weatherWindowUI;
    private DaySelectorElement[] daySelectorElements;
    private CityData _cityData;
    public void Initialise(Dictionary<ForecastDayData ,WeatherListOfDay> weather, CityData cityData)
    {
        weatherDays = weather;
        _cityData = cityData;
        LoadDate();
    }

    public void LoadDate()
    {
        ClearDayLoader();
        daySelectorElements = new DaySelectorElement[weatherDays.Count];
        int i = 0;
        Debug.Log(weatherDays.Keys.Count);
        foreach (var day in weatherDays.Keys)
        {
                DaySelectorElement element = Instantiate(_butonPrefab, dayLoaderTransform);
                element.Initialisation(i, day);
                element.onButtonClicked += OnDayLoaderUpdated;
                element.onButtonClicked += OnSelectButon;
                daySelectorElements[i] = element;
                i++;
        }

        if (daySelectorElements.Length > 0)
        {
            SelectFirstDay();
        }
    }

    public void ClearDayLoader()
    {
        for (int i = 0; i < dayLoaderTransform.childCount; i++)
        {
            Destroy(dayLoaderTransform.GetChild(i).gameObject);
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
            var day = weatherDays[dayButonInfo.GetForecastForecastDayData];
            if (day == null)
            {
                throw new Exception("���� ����� �� ���������");
            }
            onDayLoaderUpdated.Invoke(day);
        }

    private void SelectFirstDay()
    {
        daySelectorElements[0].OnButtonClicked();
    }
    
}
