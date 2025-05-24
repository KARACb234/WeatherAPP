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
    private TextMeshProUGUI _latitudeText;
    [SerializeField]
    private TextMeshProUGUI _longitudeText;
    private CityData _cityData;
    public Action<CityData> onButtonClicked = delegate { };
    private float _latitude;
    private float _logitude;

    public void Initialize(CityData cityData, Action<CityData> onWeatherWindowOpen)
    {
        _cityData = cityData;
        string cityName = string.Format("{0} {1}", cityData.GetCountryName, cityData.CityName);
        _countryAndCityNameText.text = cityName;
        _latitudeText.text += cityData.Latitude.ToString();
        _longitudeText.text += cityData.Longitude.ToString();
        onButtonClicked = onWeatherWindowOpen;
        _latitude = cityData.Latitude;
        _logitude = cityData.Longitude;
    }

    public void OnButtonClicked()
    {
        onButtonClicked?.Invoke(_cityData);
    }
}
