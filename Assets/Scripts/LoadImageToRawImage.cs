using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json.Serialization;

public class LoadImageToRawImage : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImage;
    private CityElement _cityElement;
    void Start()
    {
        _cityElement = GetComponentInParent<CityElement>();
        StartCoroutine(DownloadImageCoroutine(_cityElement.CityIconId));
    }
    void Update()
    {
        
    }
    private IEnumerator DownloadImageCoroutine(string iconId)
    {
        string imageReference = $"https://img.icons8.com/?size=100&id={iconId}&format=png&color=000000";
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageReference))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"НЕ получилось загрузить картинку{request.error}");
            }
            else
            {
                Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(request);
                _rawImage.texture = downloadedTexture;
            }
        }
    }
}
