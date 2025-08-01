using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CityElementController
{
    private List<CityElement> _cityElements;
    private int _cityElementsAmount;
    private int _downloadedCityElementsAmount;

    public CityElementController(List<CityElement> cityElements)
    {
        _cityElements = cityElements;
        _cityElementsAmount = _cityElements.Count;
    }
    public void Refresh(string userInput)
    {
        string inputText = Regex.Replace(userInput, @"[^a-z0-9?-??\s]", string.Empty, RegexOptions.IgnoreCase).ToLower();
        if (userInput.Length == 0)
        {
            foreach (CityElement cityElement in _cityElements)
            {
                cityElement.gameObject.SetActive(true);
            }
            return;
        }
        Dictionary<CityElement, int> citiesPreoryti = new Dictionary<CityElement, int>();
        List<int> levenshteinDistances = new List<int>();
        foreach (var cityElement in _cityElements)
        {
            int levenshteinDistance = CalculatingLevenshteinDistance.LevenshteinDistance(cityElement.GetCityName, userInput);
            citiesPreoryti.Add(cityElement, levenshteinDistance);
            levenshteinDistances.Add(levenshteinDistance);
        }
        var sorted = citiesPreoryti.OrderBy(x => x.Value).Take(10);
        foreach (var cityElement in _cityElements)
        {
            cityElement.gameObject.SetActive(false);
        }
        foreach (var cityElement in sorted)
        {
            cityElement.Key.gameObject.SetActive(true);
            cityElement.Key.transform.SetAsLastSibling();
        }
    }
}
