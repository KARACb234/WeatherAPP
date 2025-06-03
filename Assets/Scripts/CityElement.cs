using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CityElement : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _countryAndCityNameText;
    [SerializeField]
    private TextMeshProUGUI _coordinatesText;
    private CityData _cityData;
    public Action<CityData> onButtonClicked = delegate { };
    private float _latitude;
    private float _logitude;
    private string _cityIconId;
    public string CityIconId => _cityIconId;

    public void Initialize(CityData cityData, Action<CityData> onWeatherWindowOpen)
    {
        _cityData = cityData;
        string cityName = string.Format("{0}, {1}", cityData.GetCountryName, cityData.CityName);
        _countryAndCityNameText.text = cityName;
        _latitude = cityData.Latitude;
        _logitude = cityData.Longitude;
        string coordinates = string.Format("широта: {0} долгота: {1}", _latitude, _logitude);
        _coordinatesText.text = coordinates;
        onButtonClicked = onWeatherWindowOpen;
        _cityIconId = cityData.IconId;
    }

    public void OnButtonClicked()
    {
        onButtonClicked?.Invoke(_cityData);
    }
}
