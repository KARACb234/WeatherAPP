using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DaySelectorElement : MonoBehaviour
{
    private Button button;
    public Button GetButton => button;
    private TextMeshProUGUI label;
    private DateTime _date;
    private int _index;
    public event Action<DayButonInfo> onButtonClicked = delegate { };

    public void Initialisation(DateTime date, int index)
    {
        _date = date;
        _index = index;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
        UpdateLable();
    }

    public void OnButtonClicked()
    {
        DayButonInfo dayButonInfo = new DayButonInfo(_date, _index);
        onButtonClicked.Invoke(dayButonInfo);
    }
    public void UpdateLable()
    {
        label = GetComponentInChildren<TextMeshProUGUI>();
        label.text = _date.ToString("dd MMMM");
    }
}
