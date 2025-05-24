using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JsonData;
using System;
using Assets.Scripts;

public class WelcomeWindow : WindowBase
{
    [SerializeField]
    private TextMeshProUGUI timeText;
    private WelcomePresenter welcomePresenter;
    [SerializeField]
    private CityElementLoader cityElementLoader;
    public Action<CityData> onWeatherWindowOpen = (cityData) => {};

    private async void Start()
    {
        welcomePresenter = new WelcomePresenter();
        List<CityData> citiesDatas = await WeatherUpdate.GetCityData();
        onWeatherWindowOpen += welcomePresenter.OpenWindow;
        cityElementLoader.Initialize(onWeatherWindowOpen, citiesDatas);
    }
    private void Update()
    {
        timeText.SetText($"Время: {DateTime.Now.ToString("HH:mm:ss")}");
    }
}
