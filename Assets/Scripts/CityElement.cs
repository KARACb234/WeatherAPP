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
    public Action<float, float> onButtonClicked = delegate { };
    private float _latitude;
    private float _logitude;

    public void Initialize(string countryAndCityNameText, float latitude, float longitude, Action<float ,float> onWeatherWindowOpen)
    {
        _countryAndCityNameText.text = countryAndCityNameText;
        _latitudeText.text += latitude.ToString();
        _longitudeText.text += longitude.ToString();
        onButtonClicked = onWeatherWindowOpen;
        _latitude = latitude;
        _logitude = longitude;
    }

    public void OnButtonClicked()
    {
        onButtonClicked?.Invoke(_latitude, _logitude);
    }
}
