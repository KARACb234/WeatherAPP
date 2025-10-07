using UnityEngine;
using System;


public class HourElement
{
    private DateTime _timeText;
    public DateTime TimeText => _timeText;
    private float _temperature;
    public float Temperature => _temperature;
    private string _imageURL;
    public string ImageURL => _imageURL;


    public HourElement(DateTime timetext, float temperature, string imageURL)
    {

        _timeText = timetext;
        _temperature = temperature;
        _imageURL = imageURL;
    }
    
}