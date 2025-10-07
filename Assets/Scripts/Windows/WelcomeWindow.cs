using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Assets.Scripts;
using UnityEngine.UI;

public class WelcomeWindow : WindowBase
{
    private WelcomePresenter welcomePresenter;
    [SerializeField]
    private CityElementLoader _cityElementLoader;
    public Action<CityData> onWeatherWindowOpen = (cityData) => {};
    private CityElementController _cityElementController;
    [SerializeField]
    private TMP_InputField _userInput;
    private int _cityAmount;
    [SerializeField]
    private TextMeshProUGUI progressText;
    [SerializeField]
    private Slider _progressLine;
    [SerializeField]
    private GameObject loadingWindow;

    

    private async void Start()
    {
        welcomePresenter = new WelcomePresenter();
        List<CityData> citiesDatas = await WeatherUpdate.GetCityData();
        onWeatherWindowOpen += welcomePresenter.OpenWindow;
        _cityElementLoader.Initialize(onWeatherWindowOpen, citiesDatas);
        _cityElementController = new CityElementController(_cityElementLoader.CitiesElements);
        _cityAmount = _cityElementLoader.CitiesDatas.Count;
        _progressLine.maxValue = _cityAmount;
        _cityElementLoader.onLoadedCitiesCountChanged += TextChange;
        _cityElementLoader.onLoadedCitiesCountChanged += CloseLoadingWindow;
    }
    private void Update()
    {

    }

    public void OnSearchedCityElementController()
    {
        _cityElementController.Refresh(_userInput.text);
    }
    
    private void TextChange(int loadedCityAmount)
    {
        double downloadProgressInPercent = (double)loadedCityAmount / (double)_cityAmount * 100;
        progressText.text = $"{loadedCityAmount} / {_cityAmount} ({downloadProgressInPercent.ToString("f0")}%)"; 
        _progressLine.value = 1;
    }
    private void CloseLoadingWindow(int loadedCityAmount)
    {
        if (loadedCityAmount >= 0)
        {
            loadingWindow.SetActive(false);
        }
    }
}
