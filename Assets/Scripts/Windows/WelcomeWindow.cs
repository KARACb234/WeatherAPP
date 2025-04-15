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
    public Action<float, float> onWeatherWindowOpen = (lat, lon) => {};
    private void Start()
    {
        welcomePresenter = new WelcomePresenter();
        onWeatherWindowOpen += welcomePresenter.OpenWindow;
        cityElementLoader.Initialize(onWeatherWindowOpen);
    }
    private void Update()
    {
        timeText.SetText($"Время: {DateTime.Now.ToString("HH:mm:ss")}");
    }
}
