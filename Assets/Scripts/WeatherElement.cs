using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WeatherElement : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timeOfDay;
    public TextMeshProUGUI TimeOfDay
    {
        get { return _timeOfDay; }
    }

    [SerializeField]
    private TextMeshProUGUI _temperature;
    public TextMeshProUGUI Temperature
    {
        get { return _temperature; }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
