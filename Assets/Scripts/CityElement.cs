using UnityEngine;
using TMPro;
using System;
using UnityEngine.Serialization;

public class CityElement : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _countryAndCityNameText;
    private string _cityName;
    public string GetCityName => _cityName;
    [SerializeField]
    private TextMeshProUGUI _CountryNameText;
    private CityData _cityData;
    public Action<CityData> onButtonClicked = delegate { };
    private string _cityIconId;
    public string CityIconId => _cityIconId;
    [SerializeField]
    private LoadImageToRawImage _loadImage;
    public Action onCityElementReady = delegate { };

    public void Initialize(CityData cityData, Action<CityData> onWeatherWindowOpen)
    {
        _cityData = cityData;
        string cityName = cityData.CityName;
        _cityName = cityData.CityName;
        _countryAndCityNameText.text = cityName;
        _CountryNameText.text = cityData.GetCountryName;
        onButtonClicked = onWeatherWindowOpen;
        _cityIconId = cityData.IconId;
        _loadImage.Initialize($"https://img.icons8.com/?size=100&id={_cityIconId}&format=png&color=000000");
        _loadImage.DownloadComplete += CityElementReady;
    }

    public void OnButtonClicked()
    {
        onButtonClicked?.Invoke(_cityData);
    }
    private void CityElementReady()
    {
        onCityElementReady?.Invoke();
    }
}
