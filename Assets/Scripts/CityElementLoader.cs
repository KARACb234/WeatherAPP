using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityElementLoader : MonoBehaviour
{
    [SerializeField]
    private Transform contentTransform;
    [SerializeField]
    private CityElement _cityElement;
    [SerializeField]
    private CityData[] citesData;
    public void Initialize(Action<float, float> onWeatherWindowOpen)
    {
        Load(onWeatherWindowOpen);
    }

    public void Load(Action<float, float> onWeatherWindowOpen)
    {
        foreach (CityData city in citesData)
        {
            CityElement cityElement = Instantiate(_cityElement, contentTransform);
            cityElement.Initialize(city.GetCountryAndCityName, city.Latitude, city.Longitude, onWeatherWindowOpen);
        }
    }
}
