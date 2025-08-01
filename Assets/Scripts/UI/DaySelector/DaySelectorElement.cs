using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using JsonData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DaySelectorElement : MonoBehaviour
{
    private Button button;
    public Button GetButton => button;
    private TextMeshProUGUI label;
    private ForecastDayData  _forecastDayData;
    private int _index;
    public event Action<DayButonInfo> onButtonClicked = delegate { };

    public void Initialisation(int index, ForecastDayData  dayData)
    {
        _index = index;
        _forecastDayData = dayData;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
        UpdateLable();
    }

    public void OnButtonClicked()
    {
        DayButonInfo dayButonInfo = new DayButonInfo(_index, _forecastDayData);
        onButtonClicked.Invoke(dayButonInfo);
    }
    public void UpdateLable()
    {
        label = GetComponentInChildren<TextMeshProUGUI>();
        label.text = _forecastDayData.date.ToString("dd MMMM");
    }
}
