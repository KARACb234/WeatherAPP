using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherByHourView : MonoBehaviour
{
    [SerializeField]
    private ScrollRect _scrollRect;
    [SerializeField]
    private Button _leftButton;
    public Button GetLeftButton => _leftButton;
    [SerializeField]
    private Button _rightButton;
    public Button GetRightButton => _rightButton;
    public void GoToScrol(float step)
    {
        float position = Mathf.Clamp(step, 0f, 1f);
        _scrollRect.horizontalNormalizedPosition = position;
        Debug.Log(_scrollRect.horizontalNormalizedPosition);
    }

    public float GetHorizontalNormalizedPosition()
    {
        float position = Mathf.Clamp(_scrollRect.horizontalNormalizedPosition, 0f, 1f);
        return position;
    }
}
