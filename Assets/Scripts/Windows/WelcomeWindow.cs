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
    private CityElementLoader _cityElementLoader;
    public Action<CityData> onWeatherWindowOpen = (cityData) => {};
    private CityElementController _cityElementController;
    [SerializeField]
    private TMP_InputField _userInput;
    

    private async void Start()
    {
        welcomePresenter = new WelcomePresenter();
        List<CityData> citiesDatas = await WeatherUpdate.GetCityData();
        onWeatherWindowOpen += welcomePresenter.OpenWindow;
        _cityElementLoader.Initialize(onWeatherWindowOpen, citiesDatas);
        _cityElementController = new CityElementController(_cityElementLoader.CitiesElements);
    }
    private void Update()
    {
        timeText.SetText($"Время: {DateTime.Now.ToString("HH:mm")}");
    }

    public void OnSearchedCityElementController()
    {
        _cityElementController.Refresh(_userInput.text);
    }
}
