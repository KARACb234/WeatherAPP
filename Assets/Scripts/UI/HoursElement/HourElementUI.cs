using UnityEngine;
using TMPro;

public class HourElementUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timeText;
    [SerializeField]
    private TextMeshProUGUI _temperatureText;
    [SerializeField]
    private LoadImageToRawImage _loadImage;

    public void CreateUI(string timeText, float temperature, string imageURL)
    {
        _timeText.text = timeText;
        _temperatureText.text = $"{temperature.ToString("F1")} °C";
        _loadImage.Initialize(imageURL);
    }
}
