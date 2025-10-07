using Assets.Scripts;
using JsonData;
using System;
using System.Collections.Generic;
using TMPro;
using UI.HoursElement;
using UI.HoursElementScrol;
using UnityEngine;

public class WeatherWindowUI : WindowBase
{
    [SerializeField]
    private TextMeshProUGUI curentTemperatureText;
    [SerializeField]
    private TextMeshProUGUI fellingAsText;
    [SerializeField]
    private TextMeshProUGUI isCloudText;
    [SerializeField]
    private TextMeshProUGUI _pressureText;
    [SerializeField]
    private TextMeshProUGUI avghumidityText;
    [SerializeField]
    private DayLoader dayLoader;
    private CityData _cityData;
    [SerializeField]
    private TextMeshProUGUI _windKph;
    [SerializeField]
    private Transform controlerTransform;
    [SerializeField]
    private LoadImageToRawImage loadImageToRawImage;
    [SerializeField]
    private WeatherByHourView _weatherByHourView;
    private WeatherByHourPresenter _weatherByHourPresenter;
    private HourElementsController _hourElementsController;
    [SerializeField]
    private HourElementCreator _hourElementCreator;
    [SerializeField] 
    private Transform _hourElementsScrol;
    public void Initialize()
    {
        ShowInformatoinPerCureentDay();
        WeatherByHourPresenter weatherByHourPresenter = new WeatherByHourPresenter(_weatherByHourView);
        _weatherByHourPresenter = weatherByHourPresenter;
        HourElementsController hourElementsController = new HourElementsController(_hourElementsScrol, _hourElementCreator);
        _hourElementsController = hourElementsController;
    }

    private void OnDestroy()
    {
        _weatherByHourPresenter.Destroy();
    }
    public void ShowInformatoinPerCureentDay()
    {
        var day = WeatherConfig.current;
        curentTemperatureText.text = day.tempC.ToString();
        fellingAsText.text = $"Ощущается как {day.feelslike_c.ToString()} °C";
        isCloudText.text = day.condition.text;
        _pressureText.text = day.pressure_mb.ToString();
        _windKph.text = $"{day.wind_kph.ToString()}Км/ч";
        avghumidityText.text = $"{day.humidity.ToString()}%";
        string iconURL = day.condition.icon.Substring(2);
        loadImageToRawImage.Initialize(iconURL);
    }
    

    public void CloseWindow()
    {
        WindowManager.Instance.CloseWindow(this);
    }
}
