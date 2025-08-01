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
    private List<CityData> _citiesDatas;
    public List<CityData> CitiesDatas => _citiesDatas;
    private List<CityElement> _citiesElements = new List<CityElement>();
    public List<CityElement> CitiesElements => _citiesElements;
    public int loadedCitiesCount;
    public Action<int> onLoadedCitiesCountChanged;
    public void Initialize(Action<CityData> onWeatherWindowOpen, List<CityData> citiesDatas)
    {
        _citiesDatas = citiesDatas;
        Load(onWeatherWindowOpen);
    }

    public void Load(Action<CityData> onWeatherWindowOpen)
    {
        foreach (CityData city in _citiesDatas)
        {
            CityElement cityElement = Instantiate(_cityElement, contentTransform);
            cityElement.Initialize(city, onWeatherWindowOpen);
            _citiesElements.Add(cityElement);
            cityElement.onCityElementReady += IncreasingLoadedCities;
        }
    }

    private void IncreasingLoadedCities()
    {
        loadedCitiesCount += 1;
        onLoadedCitiesCountChanged.Invoke(loadedCitiesCount);
    }
}
