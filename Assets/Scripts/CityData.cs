using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "city" ,menuName = "Create/NewCity")]
public class CityData : ScriptableObject
{
    [SerializeField]
    private string countryAndCityName;
    public string GetCountryAndCityName => countryAndCityName;
    [SerializeField]
    private float _latitude;
    public float Latitude => _latitude;
    [SerializeField]
    private float _longitude;
    public float Longitude => _longitude;
}
