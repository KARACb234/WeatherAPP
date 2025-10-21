using Assets.Scripts;
using JsonData;
using System;
using System.Collections.Generic;
using TMPro;
using UI.HoursElement;
using UI.HoursElementScrol;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    private Gradient _backGroundGradient;
    private decimal _temperature;
    [SerializeField]
    private Image _backGroudImage;
    public void Initialize()
    {
        ShowInformatoinPerCureentDay();
        WeatherByHourPresenter weatherByHourPresenter = new WeatherByHourPresenter(_weatherByHourView);
        _weatherByHourPresenter = weatherByHourPresenter;
        HourElementsController hourElementsController = new HourElementsController(_hourElementsScrol, _hourElementCreator);
        _hourElementsController = hourElementsController;
        ChooseBackGroundColor();
    }

    private void OnDestroy()
    {
        _weatherByHourPresenter.Destroy();
    }
    public void ShowInformatoinPerCureentDay()
    {
        var day = WeatherConfig.current;
        _temperature = day.tempC;
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

    public void ChooseBackGroundColor()
    {
        float temp = Convert.ToSingle(_temperature);
        temp = Mathf.Clamp(temp, -30, 30);
        float normalisedTemp = Mathf.InverseLerp(-30, 30, temp);
        Color color = _backGroundGradient.Evaluate(normalisedTemp);
        Color.RGBToHSV(color, out float h, out float s, out float v);
        v = 0.6f;
        Color newColor = Color.HSVToRGB(h, s, v);
        _backGroudImage.color = newColor;
        
    }
}
